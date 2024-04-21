using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollState2 : IState2
{
    public void OnEnter(Enemy enemy)
    {
        Debug.Log("Roll");
        enemy.Anim.Play("Roll");
    }

    public void OnExecute(Enemy enemy)
    {
        enemy.ChangeDirection(enemy.Target.transform.position.x > enemy.transform.position.x);
        enemy.RollAttack();
        enemy.Moving();
    }

    public void OnExit(Enemy enemy)
    {
        
    }
}
