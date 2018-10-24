using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public TMPro.TextMeshProUGUI highScoreText;
    private DataController dataController;

    public void Start()
    {
        dataController = FindObjectOfType<DataController>();
        highScoreText.text = dataController.GetHighestPlayerScore().ToString();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }


    public void QuitGame()
    {
        Debug.Log("Quiting Game...");
        Application.Quit();
    }
}
