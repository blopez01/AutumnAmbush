using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject[] enemyTypes = new GameObject[3];
    private GameObject[] enemyRemaining;
    public Transform spawnLocation;
    public int iWaveNumber = 0;
    public float fNextWaveTime = 10f;
    public float fTimeBetweenSpawn = 5f;

    private bool bGameOver = false;
    public GameObject gameOverScreen;
    

    //randomly selects enemies
    int iRandom;

    void Start()
    {
        iRandom = Random.Range(0, 3);
        Instantiate(enemyTypes[iRandom], spawnLocation.position, new Quaternion(0, 0, 90, 0)); //spawn enemy
    }

    // keeps track of how many enemies are currently in the scene
    void Update()
    {
        if (bGameOver)
            return;

        if (PlayerStatus.iHearts <= 0)
        {
            GameOver();
        }
        enemyRemaining = GameObject.FindGameObjectsWithTag("Enemy");

        // start next wave when previous wave has been defeated
        if (enemyRemaining.Length == 0)
        {
            StartCoroutine(NextWave());
        }
    }
    // Spawns a new wave of enemy gameobjects
    IEnumerator NextWave()
    {
        iWaveNumber++;
        for (int i = 0; i <= iWaveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(fTimeBetweenSpawn);
        }
        
        fTimeBetweenSpawn -= 0.1f;
        if (fTimeBetweenSpawn < 0)
        {
            fTimeBetweenSpawn = 0.01f;
        }
        PlayerStatus.iGold += 50 - iWaveNumber;
        if (iWaveNumber > 100)
        {
            PlayerStatus.iGold += 10;
            yield break;
        }
        PlayerStatus.iGold += 100 - iWaveNumber;
    }
    // spawns a random enemy from the list of enemyTypes
    void SpawnEnemy()
    {
        iRandom = Random.Range(0, 3);
        Instantiate(enemyTypes[iRandom], spawnLocation.position, new Quaternion(0, 0, 90, 0)); //spawn enemy
    }
    void GameOver()
    {
        bGameOver = true;
        gameOverScreen.SetActive(true);
    }
}
