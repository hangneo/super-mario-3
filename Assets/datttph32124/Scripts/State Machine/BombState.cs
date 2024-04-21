using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombState : IState
{
    float timer;

    int throwCount;

    public void OnEnter(Boss boss)
    {
        boss.FireCount = 0;
        boss.StopMoving();

        timer = 0;
    }

    public void OnExecute(Boss boss)
    {
        //boss.IsInSight = boss.CheckInSight();
        //boss.IsInSight2 = boss.CheckInSight2();

        if (boss.IsAttack)
        {
            boss.StartCoroutine(boss.DelayAttack(0.5f));
        }

        if (boss.FireCount == 2)
        {
            boss.FireCount = 0;
            boss.MoveRandom = Random.Range(1, 4);

            switch (boss.MoveRandom)
            {
                case 1:
                    boss.transform.position = boss.PlatList[0].position;
                    break;

                case 2:
                    boss.transform.position = boss.PlatList[1].position;
                    break;

                case 3:
                    boss.transform.position = boss.PlatList[2].position;
                    break;
            }
        }

        //if (boss.IsInSight || boss.IsInSight2)
        //{
        //    boss.ChangeState(new RollState());
        //}

        timer += Time.deltaTime;
        if (timer >= 1.5f)
        {
            boss.ChangeState(new PatrolState());
        }
    }

    public void OnExit(Boss boss)
    {
        boss.FireCount = 0;
    }

}
