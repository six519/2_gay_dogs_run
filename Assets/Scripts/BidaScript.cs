using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BidaScript : MonoBehaviour
{
    private Animator thisAnimator;
    void Start()
    {
        thisAnimator = this.GetComponent<Animator>();


        if (GlobalVariableScript.SelectedCharacter == 0)
        {
            thisAnimator.runtimeAnimatorController = Resources.Load("1") as RuntimeAnimatorController;
        } else
        {
            thisAnimator.runtimeAnimatorController = Resources.Load("2_1") as RuntimeAnimatorController;
        }

    }
}