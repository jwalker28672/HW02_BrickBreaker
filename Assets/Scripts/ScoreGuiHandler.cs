using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreGuiHandler : MonoBehaviour
{
    
    private GameObject gameManager;
    public TMP_Text guiScore;
    public TMP_Text Lives;


    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        getScore();
        getLives();
    }

    private void getScore()
    {
        guiScore.text = "Score: " + GameManager.instance.score;
    }

    private void getLives()
    {
        Lives.text = "Lives: " + GameManager.instance.lives;
    }
}
