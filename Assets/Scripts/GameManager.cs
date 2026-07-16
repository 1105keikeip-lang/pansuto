using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<Enemy> enemies = new List<Enemy>();
    public Slingshot player;

    float stopTimer = 0f;
    float stopThreshold = 0.2f;

    public GameObject enemyTurnPanel;
    public TMPro.TextMeshProUGUI turnText;

    bool playerHasMoved = false;
   
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
            if(player.rb.linearVelocity.magnitude > 0.1f)
            {
                playerHasMoved = true;
            }

            if(playerHasMoved && player.IsStopped())
            {
                stopTimer += Time.deltaTime;
                if(stopTimer >= stopThreshold)
                {
                    stopTimer = 0f;
                    playerHasMoved = false;
                    EndPlayerTurn();
                }
            }
            // プレイヤーが動いている間は待つ
            
            else
            {
                stopTimer = 0f;
            }
        }
    }

    void EndPlayerTurn()
    {
        state = BattleState.EnemyTurn;

        turnText.text = "Enemy Turn";
        enemyTurnPanel.SetActive(true);

        StartCoroutine(EnemyPhaseCoroutine());
    }

    IEnumerator EnemyPhaseCoroutine()
    {
        yield return new WaitForSeconds(1f);
        Breath lastBreath = null;

        foreach (var enemy in new List<Enemy>(enemies))
        {
            if (enemy != null)
            {
                Breath b = enemy.OnEnemyTurn();
                if(b != null)
                {
                    lastBreath = b;
                }
            }
            
        }

        if(lastBreath != null)
        {
            yield return new WaitForSeconds(lastBreath.lifeTime);
        }

        // 敵のターンが終わったらプレイヤーへ
        state = BattleState.PlayerTurn;
        player.ResetTurn();

        turnText.text = "Player Turn";
        enemyTurnPanel.SetActive(false);
    }

    
}
