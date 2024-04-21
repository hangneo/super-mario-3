using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private String currentAnimName;

    public Animator Anim { get => anim; set => anim = value; }

    public void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            Anim.ResetTrigger(animName);
            currentAnimName = animName;
            Anim.SetTrigger(currentAnimName);
        }
    }
}
