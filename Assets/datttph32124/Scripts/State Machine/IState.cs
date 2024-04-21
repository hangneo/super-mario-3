using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void OnEnter(Boss boss);

    void OnExecute(Boss boss);

    void OnExit(Boss boss);
}
