using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState2 : IState2
{
    public void OnEnter(Enemy enemy)
    {
        enemy.FireCount = 0;
        enemy.StopMoving();
    }

    public void OnExecute(Enemy enemy)
    {

        if (enemy.IsAttack)
        {
            enemy.StartCoroutine(enemy.DelayAttack(0.5f));
        }

        if (enemy.FireCount == 2)
        {
            enemy.ChangeState(new PatrolState2());
        }
    }

    public void OnExit(Enemy enemy)
    {
        enemy.FireCount = 0;
    }
}
