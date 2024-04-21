using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState2 
{
    void OnEnter(Enemy enemy);
    void OnExecute(Enemy enemy);
    void OnExit(Enemy enemy);
}
