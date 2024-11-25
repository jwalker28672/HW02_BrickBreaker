using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePackPowerUp : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Paddle"))
        {
            GameManager.instance.addLife();
            Destroy(this.gameObject);
        }
    }
}
