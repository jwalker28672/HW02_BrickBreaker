using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    private GameObject gameManager;
    public GameObject paddle;
    public float speed = 200f;

    private Rigidbody2D ballRb;
    
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        Invoke(nameof(moveBall), 1f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void moveBall()
    {
        
        Vector2 force = Vector2.zero;

        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        ballRb.AddForce(force.normalized * speed);
        
    }

    private void resetBall()
    {
        transform.position = Vector2.zero;
        ballRb.velocity = Vector2.zero;
        Invoke(nameof(moveBall), 1f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("OutOfBounds"))
        {
            GameManager.instance.lostLife();
            resetBall();
        }
          
    }


}
