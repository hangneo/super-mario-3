using UnityEngine;

public class trap : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private bool isPlayerTouching = false;
    private float timeSinceTouch = 0f;
    private bool isFalling = false;

    public float timeThreshold = 3f;
    public float destroyDelay = 2f;
    private float fallGravityScale = 10f; // Điều chỉnh giá trị này để tăng tốc độ rơi

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (isPlayerTouching)
        {
            timeSinceTouch += Time.deltaTime;
            if (timeSinceTouch >= timeThreshold && !isFalling)
            {
                StartFalling();
            }
        }
        else
        {
            timeSinceTouch = 0f;
        }

        if (isFalling)
        {
            Destroy(gameObject, destroyDelay);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerTouching = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerTouching = false;
        }
    }

    void StartFalling()
    {
        isFalling = true;
        boxCollider.enabled = false; // Tắt collider để không va chạm khi rơi
        rb.bodyType = RigidbodyType2D.Dynamic; // Chuyển sang dynamic để rơi tự do
        rb.gravityScale = fallGravityScale; // Tăng tốc độ rơi bằng cách điều chỉnh gravityScale
    }
}
