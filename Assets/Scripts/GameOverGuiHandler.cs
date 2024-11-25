using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverGuiHandler : MonoBehaviour
{

    public TMP_Text finalScore;

    void Start()
    {
        finalScore.text = "Score: " + GameManager.instance.score;
    }


    public void playAgain()
    {
        GameManager.instance.playGame();
    }

    public void mainMenu()
    {
        GameManager.instance.mainMenu();
    }

}
