using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrickSpawner : MonoBehaviour
{
    public GameObject[] bricks;
    public GameObject spawnLocation;
    private float xPos;
    private float yPos;
    private float chance;
    private int variation;

    void Start()
    {
        xPos = spawnLocation.transform.position.x;
        yPos = spawnLocation.transform.position.y;
        spawnBrick();

    }

    void Update()
    {

    }

    public void spawnBrick()
    {
        chance = UnityEngine.Random.value;

        if(chance < .10)
        {
            variation = 2;
        }
        else if(chance < .40)
        {
            variation = 1;
            GameManager.instance.addBricks();
        }
        else if(chance < 1)
        {
            variation = 0;
            GameManager.instance.addBricks();
        }

        GameObject spawnedBrick = bricks[variation];

        Instantiate(spawnedBrick,new Vector3(xPos, yPos, 0), Quaternion.identity);


    }
}
