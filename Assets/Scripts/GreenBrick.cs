using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBrick : MonoBehaviour
{
    private GameObject gameManager;
    private int variation;
    private int BrickHealth;
    private float xPos;
    private float yPos;

    public GameObject spawnLocation;
    public GameObject[] powerUps;
    public Sprite crackedBrick;
    public int points = 1;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        BrickHealth = 2;
        xPos = spawnLocation.transform.position.x;
        yPos = spawnLocation.transform.position.y;
    }

    private void hitBrick()
    {
        BrickHealth--;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = crackedBrick;

        if (BrickHealth <= 0)
        {
            GameManager.instance.destroyBrick();
            Destroy(this.gameObject);
            powerUpDrop();
            GameManager.instance.brokenBrick(points);
        }
    }

    private void powerUpDrop()
    {
        float chance = UnityEngine.Random.value;

        if (chance < .20)
        {
            variation = 0;
        }
        else if(chance < .40)
        {
            variation = 1;
        }
        else if(chance < .60)
        {
            variation = 2;
        }


        GameObject spawnedPowerUp = powerUps[variation];

        Instantiate(spawnedPowerUp, new Vector3(xPos, yPos, 0), Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            hitBrick();
        }
    }
}
