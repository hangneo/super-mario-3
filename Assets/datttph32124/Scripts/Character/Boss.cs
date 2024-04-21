using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Boss : Character
{
    [SerializeField] private List<Transform> platList = new List<Transform>();

    [SerializeField] private HammerBullet hammerBullet;
    [SerializeField] private Transform target;

    [SerializeField] private Transform firePos;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float speed;
    [SerializeField] private float attackRange;
    [SerializeField] private float jumpForce;
    //[SerializeField] private float rotateSpeed = 400f;

    [SerializeField] private LayerMask playerLayer;

    private IState currentState;

    private HammerBullet hb;
    private Transform targetPos;

    private bool isAttack = true;
    private bool isRight = true;
    private bool isTrigger;
    private bool isInSight;
    private bool isInSight2;

    private int direction = 1;
    private int fireCount;
    private int moveRandom;

    private Character target2;

    public Character Target2 => target2;

    public Rigidbody2D Rb { get => rb; set => rb = value; }
    public float Speed { get => speed; set => speed = value; }
    public int Direction { get => direction; set => direction = value; }
    public bool IsInSight { get => isInSight; set => isInSight = value; }
    public bool IsInSight2 { get => isInSight2; set => isInSight2 = value; }
    public int FireCount { get => fireCount; set => fireCount = value; }
    public int MoveRandom { get => moveRandom; set => moveRandom = value; }
    public List<Transform> PlatList { get => platList; set => platList = value; }
    public Transform Target { get => target; set => target = value; }
    public bool IsAttack { get => isAttack; set => isAttack = value; }

    private void Start()
    {
        isTrigger = false;
        ChangeState(new IdleState());
    }

    private void Update()
    {
        Debug.Log(currentState);

        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

    public void RollAttack()
    {
        speed = 5;
        //transform.position = Vector2.MoveTowards(transform.position, targetPos.position, speed * Time.deltaTime);
        ChangeAnim("Roll");
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
            Debug.Log("ref1");
            if (!isTrigger)
            {
                ChangeDirection(!isRight);
            }
        }
    }

    public void Moving()
    {
        ChangeAnim("Run");
        rb.velocity = transform.right * speed;
        //rb.velocity = new Vector3(Speed, rb.velocity.y);
    }

    public void StopMoving()
    {
        rb.velocity = Vector2.zero;
    }

    public void ChangeDirection(bool isRight)
    {
        Debug.Log("inside");
        this.isRight = isRight;
        transform.rotation = Quaternion.Euler(0f, -180f, 0f);
        isTrigger = true;
        Invoke(nameof(ResetTrigger), 0.1f);
    }

    public void ResetTrigger()
    {
        isTrigger = false;
    }

    internal void SetTarget(Character character)
    {
        this.target2 = character;

        if (IsTargetInRange())
        {
            ChangeState(new RollState());
        }
        else if (target2 != null)
        {
            ChangeState(new PatrolState());
        }
        else
        {
            ChangeState(new IdleState());
        }
    }

    public bool IsTargetInRange()
    {
        if (target != null && Vector2.Distance(target.transform.position, transform.position) <= attackRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //public bool CheckInSight()
    //{
    //    Debug.DrawLine(transform.position, transform.position + Vector3.right * 8f, Color.red);

    //    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 8f, playerLayer);

    //    if (hit.collider != null)
    //    {
    //        direction = 1;
    //        targetPos = hit.transform;
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    //public bool CheckInSight2()
    //{
    //    Debug.DrawLine(transform.position, transform.position + Vector3.left * 11f, Color.red);

    //    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 11f, playerLayer);

    //    if (hit.collider != null)
    //    {
    //        direction = -1;
    //        targetPos = hit.transform;
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}
}
