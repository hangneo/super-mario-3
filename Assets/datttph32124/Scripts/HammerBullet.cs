using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private GameObject exploPrefab;

    private void Start()
    {
        Destroy(gameObject, 3f);

        rb.AddForce(new Vector2((Enemy.isRight ? 1 : -1) * 200f, 300f)); 

        //rb.velocity = new Vector2(-5, 10f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 9 && collision.gameObject.layer != 11 && collision.gameObject.layer != 12)
        {
            Debug.Log(collision.gameObject.name);
            Instantiate(exploPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
