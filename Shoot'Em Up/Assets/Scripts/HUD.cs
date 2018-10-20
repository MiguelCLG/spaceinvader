using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {

    public int numEnemies = 15;
    public int numWaves = 2;
    public int waveNumber = 1;
    public int score = 0;
    public GameObject enemyWavePrefab;
    public Text textScore;
    public int spawning = 1;

    public void Start()
    {
        enemyWavePrefab = Instantiate(enemyWavePrefab, new Vector3(0, 4.4f, 0), Quaternion.identity);
    }

    public void AddScore(int value)
    {
        score += value;
        textScore.text = score.ToString();
    }

    public void Frag() {
        numEnemies -= 1;

        if (numEnemies <= 0)
        {
            //Destroy(enemyWavePrefab.gameObject);
            WaveComplete();
        }
        else {
            AddScore(100);
        }
    }

    public void WaveComplete()
    {
        if (numWaves == waveNumber)
        {
            LevelComplete();
        }
        else {
            SpawnWave();
    
        }
    }

    public void SpawnWave()
    {
        waveNumber += 1;
        AddScore(400);
        numEnemies = 15;
        spawning = 1;
    }

    public void LevelComplete() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
