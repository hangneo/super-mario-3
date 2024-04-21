using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    float randomTime;
    float timer;

    public void OnEnter(Boss boss)
    {
        boss.StopMoving();
        timer = 0;
        randomTime = Random.Range(2f, 4f);
    }

    public void OnExecute(Boss boss)
    {
        timer += Time.deltaTime;

        if (timer > randomTime)
        {
            boss.ChangeState(new PatrolState());
        }
    }

    public void OnExit(Boss boss)
    {

    }
}
