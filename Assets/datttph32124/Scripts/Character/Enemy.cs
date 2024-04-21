using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : Character
{
    [SerializeField] private List<Transform> platList = new List<Transform>();

    [SerializeField] private HammerBullet hammerBullet;

    [SerializeField] private Transform firePos;

    [SerializeField] private float attackRange;
    [SerializeField] private float moveSpeed;

    [SerializeField] private Rigidbody2D rb;

    private IState2 currentState;

    public static bool isRight = true;

    private bool isAttack = true;

    private HammerBullet hb;

    private int fireCount;

    private Character target;

    private int moveRandom;

    public Character Target => target;
    public int FireCount { get => fireCount; set => fireCount = value; }
    public int MoveRandom { get => moveRandom; set => moveRandom = value; }
    public List<Transform> PlatList { get => platList; set => platList = value; }
    public bool IsAttack { get => isAttack; set => isAttack = value; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    private void Start()
    {
        ChangeState(new PatrolState2());
    }

    private void Update()
    {

        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }

    public void OnDeath()
    {

    }

    public void ChangeState(IState2 newState)
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

    public void Moving()
    {
        ChangeAnim("Run");

        rb.velocity = transform.right * MoveSpeed;
    }

    public void StopMoving()
    {
        //ChangeAnim("Idle");
        rb.velocity = Vector2.zero;
    }

    public IEnumerator DelayAttack(float delayTime)
    {
        IsAttack = false;
        yield return new WaitForSeconds(delayTime);
        NearAttack();
        IsAttack = true;
    }

    public void NearAttack()
    {
        hb = Instantiate(hammerBullet, firePos.position, Quaternion.identity);
        fireCount++;
    }

    internal void SetTarget(Character character)
    {
        this.target = character;

        if (IsTargetInRange())
        {
            ChangeState(new RollState2());
        }
        //else if (target != null)
        //{
        //    ChangeState(new PatrolState2());
        //}
        else
        {
            ChangeState(new PatrolState2());
        }
    }

    public void RollAttack()
    {
        MoveSpeed = 5;
        //ChangeAnim("Roll");
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            ChangeDirection(!isRight);
        }

        if (collision.gameObject.layer == 3)
        {
            Debug.Log("Looooooose");
        }
    }

    public void ChangeDirection(bool isRight)
    {
        Enemy.isRight = isRight;

        transform.rotation = isRight ? Quaternion.Euler(Vector3.zero) : Quaternion.Euler(Vector3.up * 180);
    }
}
