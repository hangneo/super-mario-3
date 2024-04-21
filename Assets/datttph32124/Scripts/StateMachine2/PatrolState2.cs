using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState2 : IState2
{
    float randomTime;
    float timer;

    public void OnEnter(Enemy enemy)
    {
        Debug.Log("Patrol");
        //enemy.ChangeAnim("Run");
        enemy.Anim.Play("Run");
        enemy.MoveSpeed = 2;
        timer = 0;
        randomTime = Random.Range(3f, 6f);
    }

    public void OnExecute(Enemy enemy)
    {
        timer += Time.deltaTime;

        if (enemy.Target != null)
        {
            // doi huong enemy toi huong cua player

            enemy.ChangeDirection(enemy.Target.transform.position.x > enemy.transform.position.x);


            if (enemy.IsTargetInRange())
            {
                enemy.ChangeState(new RollState2());
            }
            else
            {
                enemy.Moving();

            }

        }
        else
        {
            if (timer < randomTime)
            {
                enemy.Moving();

            }
            else
            {
                enemy.ChangeState(new IdleState2());
            }
        }

        enemy.Moving();
    }

    public void OnExit(Enemy enemy)
    {

    }
}
