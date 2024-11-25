using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void playGame()
    {
        SceneManager.LoadScene("Level01");
        Time.timeScale = 1.0f;
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
