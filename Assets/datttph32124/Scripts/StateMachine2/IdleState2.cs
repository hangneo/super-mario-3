using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState2 : IState2
{
    public void OnEnter(Enemy enemy)
    {
        Debug.Log("Idle");
        enemy.Anim.Play("Run");
        enemy.MoveSpeed = 2;
        enemy.StopMoving();

        enemy.MoveRandom = Random.Range(1, 6);

        switch (enemy.MoveRandom)
        {
            case 2:
                enemy.transform.position = enemy.PlatList[1].position;
                break;

            case 3:
                enemy.transform.position = enemy.PlatList[2].position;
                break;

            default:
                enemy.transform.position = enemy.PlatList[0].position;
                break;
        }

        enemy.ChangeState(new AttackState2());
    }

    public void OnExecute(Enemy enemy)
    {
        
    }

    public void OnExit(Enemy enemy)
    {

    }
}
