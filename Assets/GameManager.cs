using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<Enemy> enemies = new List<Enemy>();
    public Slingshot player;

    public enum BattleState
    {
        PlayerTurn,
        EnemyTurn,
        Waiting
    }

    public BattleState state = BattleState.PlayerTurn;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (state == BattleState.PlayerTurn)
        {
            // プレイヤーが動いている間は待つ
            if (player.IsStopped())
            {
                EndPlayerTurn();
            }
        }
    }

    void EndPlayerTurn()
    {
        state = BattleState.EnemyTurn;
        EnemyPhase();
    }

    void EnemyPhase()
    {
        foreach (var enemy in enemies)
        {
            enemy.OnEnemyTurn();
        }

        // 敵のターンが終わったらプレイヤーへ
        state = BattleState.PlayerTurn;
        player.ResetTurn();
    }

    
}
