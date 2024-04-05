using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private List<Transform> platList = new List<Transform>();

    [SerializeField] private HammerBullet hammerBullet;
    [SerializeField] private Transform firePos;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float speed;

    private HammerBullet hb;

    private bool isAttack = true;

    private int direction = 1;
    private int fireCount;
    private int moveRandom;

    private void Update()
    {
        if (isAttack && direction == 1)
        {
            StartCoroutine(DelayAttack(2f));
        }

        rb.velocity = new Vector3(speed * direction, 0, 0);

        if (fireCount == 2)
        {
            fireCount = 0;
            moveRandom = Random.Range(1, 4);
            Debug.Log(moveRandom);

            switch (moveRandom)
            {
                case 1:
                    transform.position = platList[0].position;
                    break;

                case 2:
                    transform.position = platList[1].position;
                    break;

                case 3:
                    transform.position = platList[2].position;
                    break;

                default:
                    break;
            }
        }
    }

    public IEnumerator DelayAttack (float delayTime)
    {
        isAttack= false;
        yield return new WaitForSeconds(delayTime);
        NearAttack();
        isAttack= true;
    }

    public void NearAttack ()
    {
        hb = Instantiate(hammerBullet, firePos);
        fireCount++;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            direction *= -1;
            rb.gameObject.transform.localScale = new Vector3(rb.gameObject.transform.localScale.x * -1, 1, 1);
        }
    }
}
