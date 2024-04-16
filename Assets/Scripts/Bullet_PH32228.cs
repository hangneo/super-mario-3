using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_PH32228 : MonoBehaviour
{
    public float life = 15;
    public float gravityScale = 1f; // Tốc độ rơi tự do của đối tượng đạn

    private void Awake()
    {
        Destroy(gameObject, life);
    }

    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = gravityScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Lấy ra đối tượng mà đạn va chạm
        GameObject collidedObject = collision.gameObject;

        // Kiểm tra nếu đối tượng va chạm có thẻ tag "Destroyable"
        if (collidedObject.CompareTag("Goomba"))
        {
            // Tiêu diệt đối tượng va chạm
            Destroy(collidedObject);
        }
        else
        {
            // Nếu không va chạm với đối tượng có thẻ tag "Destroyable",
            // thì tắt collider và kích hoạt gravity để đối tượng rơi xuống dưới ground
            GetComponent<Collider2D>().enabled = false;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = gravityScale;
            }
        }
    }
}
