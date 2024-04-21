using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        Destroy(gameObject, 3f);

        rb.AddForce(new Vector2((Enemy.isRight ? 1 : -1) * 200f, 300f)); 

        //rb.velocity = new Vector2(-5, 10f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            //Time.timeScale = 0f;
        }
    }
}
