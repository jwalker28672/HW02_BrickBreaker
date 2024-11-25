using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBrick : MonoBehaviour
{


    public Sprite damagedBrick;
    public Sprite crackedBrick;
    public GameObject spawnLocation;
    public GameObject[] powerUps;

    private int variation;
    private int BrickHealth;
    private int points = 3;
    private float xPos;
    private float yPos;

    void Start()
    {
        BrickHealth = 3;
        xPos = spawnLocation.transform.position.x;
        yPos = spawnLocation.transform.position.y;
    }


    private void hitBrick()
    {
        BrickHealth--;

        if (BrickHealth == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = damagedBrick;
        }
        else if (BrickHealth == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = crackedBrick;
        }
        else if (BrickHealth <= 0)
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
        else if (chance < .40)
        {
            variation = 1;
        }
        else if (chance < .60)
        {
            variation = 2;
        }


        GameObject spawnedPowerUp = powerUps[variation];

        Instantiate(spawnedPowerUp, new Vector3(xPos, yPos, 0), Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            hitBrick();
        }
    }
}
