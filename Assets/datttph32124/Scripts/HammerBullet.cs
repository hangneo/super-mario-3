using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        rb.velocity = new Vector2(2f, 12f);
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            //Time.timeScale = 0f;
        }
    }
}
