using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int bricksLeft;
    private int sceneNum;
    public int lives;
    public int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if(instance != this)
        {
            Destroy(instance);
        }

    }

    void Start()
    {
        sceneNum = 0;
        lives = 3;
        score = 0;
    }

    public void playGame()
    {
        sceneNum = 0;
        lives = 3;
        score = 0;
        nextScene();
        Time.timeScale = 1.0f;
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void gameOver()
    {
        SceneManager.LoadScene("GameOver");
   
    }

    public void mainMenu()
    {
        score = 0;
        lives = 3;
        sceneNum = 0;
        SceneManager.LoadScene(sceneNum);
    }

    public void nextScene()
    {
        sceneNum++;
        SceneManager.LoadScene(sceneNum);

    }

    public void addBricks()
    {
        bricksLeft++;
    }

    public void destroyBrick()
    {
        bricksLeft--;

        if(bricksLeft == 0)
        {
            nextScene();
        }
    }

    public void lostLife()
    {
        lives--;

        if (lives <= 0)
        {
            gameOver();
            lives = 3;
        }
    }

    public void addLife()
    {
        lives++;
    }

    public void brokenBrick(int points)
    {
        score += points;
    }

}
