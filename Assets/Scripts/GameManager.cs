using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject Enemy;

    [SerializeField] private List<GameObject> SpawnPoints;

    [SerializeField] private float SpawnDuration = 3;

    private int SpawnPointsCount;

    private int PlayerKillCount = 0;

    [SerializeField] private int MaxSpawnCount = 10;

    private int CurrentSpawnCount = 0;

    [SerializeField] private GameObject FinishText;

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
        
        int Random = UnityEngine.Random.Range(0, SpawnPointsCount);
        
        Instantiate(Enemy, SpawnPoints[Random].transform.position, Quaternion.identity);

        if (CurrentSpawnCount >= MaxSpawnCount)
        {
            CancelInvoke("SpawnEnemy");
        }
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
