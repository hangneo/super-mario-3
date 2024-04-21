using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollState : IState
{
    float timer;

    public void OnEnter(Boss boss)
    {
        if (boss.Target2 != null)
        {
            boss.ChangeDirection(boss.Target2.transform.position.x > boss.transform.position.x);
            Debug.Log("ref3");

            boss.StopMoving();
            //boss.StartCoroutine(boss.DelayAttack(1f));
            boss.RollAttack();
        }

        timer = 0;
    }

    public void OnExecute(Boss boss)
    {
        timer += Time.deltaTime;
        if (timer >= 1.5f)
        {
            boss.ChangeState(new PatrolState());
        }
    }

    public void OnExit(Boss boss)
    {
    }
}
