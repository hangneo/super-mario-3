using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NemVuKhi : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float arcHeight = 1f; // Độ cao của hình vòng cung
    public bool isAtt = true;
    void Update()
    {
        // Kiểm tra hướng quay của nhân vật
        bool isFacingRight = transform.localScale.x > 0;

        // Kiểm tra phím được nhấn để ném vũ khí
        if (Input.GetKeyDown(KeyCode.F) && isAtt)
        {
            // Sinh ra đối tượng đạn
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            // Tính toán hướng của đạn dựa trên hướng quay của nhân vật
            Vector2 direction = isFacingRight ? bulletSpawnPoint.right : -bulletSpawnPoint.right;

            // Tính toán góc quay của đạn
            float angle = Vector2.SignedAngle(Vector2.right, direction) * Mathf.Deg2Rad;

            // Tính toán vận tốc ban đầu của đạn
            float initialVelocityX = bulletSpeed * Mathf.Cos(angle);
            float initialVelocityY = bulletSpeed * Mathf.Sin(angle);

            // Thiết lập vận tốc cho đạn
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(initialVelocityX, initialVelocityY);

            // Áp dụng hình vòng cung
            rb.gravityScale = 1f; // Bật chế độ rơi tự do
            rb.gravityScale *= Mathf.Pow(initialVelocityY, 2) / (2 * arcHeight * Mathf.Pow(Mathf.Cos(angle), 2));

            isAtt = false;
        }
    }
}
