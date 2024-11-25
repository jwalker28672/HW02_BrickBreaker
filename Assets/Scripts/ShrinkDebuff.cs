using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkDebuff : MonoBehaviour
{
    private GameObject paddle;
    private float paddley;
    private float paddlex;
    public float time;
    private float duration;


    void Start()
    {
        paddle = GameObject.FindGameObjectWithTag("Paddle");
        paddlex = paddle.transform.localScale.x;
        paddley = paddle.transform.localScale.y;
        time = 0;
        duration = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= duration)
        {
            time += Time.deltaTime;

            shrinkPaddle();
        }
        else if (time > duration)
        {
            paddle.transform.localScale = new Vector2(paddlex, paddley);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            duration = 10;
        }
    }

    private void shrinkPaddle()
    {
        paddle.transform.localScale = new Vector2(0.5f, 0.5f);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
