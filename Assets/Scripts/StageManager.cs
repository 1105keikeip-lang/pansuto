using UnityEngine;
using System.Collections.Generic;
public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    [System.Serializable]
    public class Wave
    {
        public List<GameObject> enemyPrefabs;
        public Transform[] spawnPoints;
    }

    public List<Wave> waves = new List<Wave>();
    int currentWave = 0;

     void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartWave(0);
    }

    public void StartWave(int waveIndex)
    {
        currentWave = waveIndex;
        Wave wave = waves[waveIndex];

        for(int i = 0; i < wave.enemyPrefabs.Count; i++)
        {
            Instantiate(wave.enemyPrefabs[i], wave.spawnPoints[i].position, Quaternion.identity);
        }
    }

    public void OnEnemyKilled()
    {
        if (GameManager.Instance.enemies.Count <= 0)
        {
            currentWave++;

            if(currentWave < waves.Count)
            {
                StartWave(currentWave);
            }
            else
            {
                Debug.Log("ステージクリア");
            }
        }
    }

    // Update is called once per frame

}
