using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject Enemy;

    public List<GameObject> SpawnPoints;

    public float SpawnDuration = 3;

    private int SpawnPointsCount;

    private int PlayerKillCount = 0;

    public int MaxSpawnCount = 10;

    private int CurrentSpawnCount = 0;

    public GameObject FinishText;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FinishText.gameObject.SetActive(false);
        
        if (Enemy && SpawnPoints.Count > 0)
        {
            SpawnPointsCount = SpawnPoints.Count;
            
            InvokeRepeating("SpawnEnemy", 1, SpawnDuration);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        CurrentSpawnCount++;

        if (CurrentSpawnCount >= MaxSpawnCount)
        {
            CancelInvoke("SpawnEnemy");
            
            return;
        }
        
        int Random = UnityEngine.Random.Range(0, SpawnPointsCount - 1);
        
        Instantiate(Enemy, SpawnPoints[Random].transform.position, Quaternion.identity);
    }

    public void IncreasKillCount()
    {
        PlayerKillCount++;

        if (PlayerKillCount >= MaxSpawnCount)
        {
            GameFinished();
        }
    }

    void GameFinished()
    {
        CancelInvoke("SpawnEnemy");

        FinishText.gameObject.SetActive(true);
    }
}
