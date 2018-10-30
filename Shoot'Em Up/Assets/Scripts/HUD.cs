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

    public TMPro.TextMeshProUGUI textScore, gameOverScore, levelClearedScore, waveNumberText, highScoreText;

    public int spawning = 1;
    public bool initialSpawn = true;

    public GameObject enemyWavePrefab;
    public GameObject levelClearedMenu;
    public GameObject gameOverMenu;
    private DataController dataController;

    public void Start()
    {
        dataController = FindObjectOfType<DataController>();
        enemyWavePrefab = Instantiate(enemyWavePrefab, new Vector3(0, 4.4f, 0), Quaternion.identity);
        highScoreText.text = dataController.GetHighestPlayerScore().ToString();
    }


    public void Update()
    {
        CheckNumEnemies();
    }

    void CheckNumEnemies()
    {
        if(spawning == 0)
        {
            numEnemies = FindObjectsOfType<Enemy>().Length;
        }
    }
    public void AddScore(int value)
    {
        score += value;
        textScore.text = score.ToString();
        gameOverScore.text = score.ToString();
        levelClearedScore.text = score.ToString();
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
        /*
        if (numWaves == waveNumber)
        {
            LevelComplete();
        }
        else {
            SpawnWave();
    
        }*/
        waveNumber++;
        waveNumberText.text = waveNumber.ToString();
        SpawnWave();
    }

    public void SpawnWave()
    {
        if (waveNumber % 5 == 0)
        {
            AddScore(400);
            numEnemies = 1;
            spawning = 2;
        }
        else
        {
            AddScore(400);
            numEnemies = 15;
            spawning = 1;
        }
        
    }

    public void LevelComplete() {
        Time.timeScale = 0f;
        levelClearedMenu.SetActive(true);
    }

    public void GameOver()
    {
        dataController.SubmitNewPlayerScore(score);
        gameOverMenu.SetActive(true);

    }
}
