using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PatrolState : IState
{
    float randomTime;
    float timer;

    public void OnEnter(Boss boss)
    {
        timer = 0;
        randomTime = Random.Range(2f, 4f);

        boss.Speed = 2f;
        boss.ChangeAnim("Run");
    }

    public void OnExecute(Boss boss)
    {
        timer += Time.deltaTime;

        if (boss.Target2 != null)
        {
            boss.ChangeDirection(boss.Target2.transform.position.x > boss.transform.position.x);
            boss.Moving();
            Debug.Log("ref2");
        }

        else
        {
            if (timer < randomTime)
            {
                boss.Moving();

            }
            else
            {
                boss.ChangeState(new IdleState());
            }
        }

    }

    public void OnExit(Boss boss)
    {
    }
}
