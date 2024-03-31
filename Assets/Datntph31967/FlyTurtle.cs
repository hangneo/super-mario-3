using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTurtleTienDat : MonoBehaviour
{
    public Transform[] waypoint;
    float moveSpeed = 5f;
    int wayPointIndex = 0;
    private bool shelled;
    public Sprite shellSprite;
    public Sprite nomalSprite;
    private bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoint[wayPointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FlyTrutleMove();
    }
    void FlyTrutleMove()
    {
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoint[wayPointIndex].position, moveSpeed * Time.deltaTime);
            if (transform.position == waypoint[wayPointIndex].position)
            {
                wayPointIndex++;
            }
            if (wayPointIndex == waypoint.Length)
            {
                wayPointIndex = 0;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!shelled && collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player.starpower)
            {
                Hit();
            }
            else if (collision.transform.DotTest(transform, Vector2.down))
            {
                EnterShell();
                canMove = false;
                StartCoroutine(ReactivateMoveAfterDelay(3f));
            }
            else
            {
                player.Hit();
            }
        }
    }
    private IEnumerator ReactivateMoveAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Đợi 3 giây
        OutShell();
        transform.position = Vector2.MoveTowards(transform.position, waypoint[0].position, moveSpeed * Time.deltaTime);
        canMove = true; 
    }
    private void EnterShell()
    {
        shelled = true;

        GetComponent<SpriteRenderer>().sprite = shellSprite;
        GetComponent<FlyTurtleAnimated>().enabled = false;
        GetComponent<FlyTurtleDeadAnimation>().enabled = false;
    }
    private void OutShell()
    {
        shelled = false;
        GetComponent<SpriteRenderer>().sprite = nomalSprite;
        GetComponent <FlyTurtleAnimated>().enabled = true;
        GetComponent<FlyTurtleDeadAnimation>().enabled=false;
    }
    private void Hit()
    {
        GetComponent<FlyTurtleAnimated>().enabled = false;
        GetComponent<FlyTurtleDeadAnimation>().enabled = true;
    }
}
