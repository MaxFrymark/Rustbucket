using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField] Animator bodyAnimator;

    [SerializeField] Animator frontLegAnimator;
    [SerializeField] Animator backLegAnimator;

    public delegate void SetMovementAnimation(bool isMoving);
    public SetMovementAnimation setMovementAnimation;

    private void Start()
    {
        setMovementAnimation = SetBodyAnimation;
    }

    public void SwitchToLegMovement()
    {
        setMovementAnimation(false);
        setMovementAnimation = SetLegAnimation;
    }


    public void SetBodyAnimation(bool isMoving)
    {
        bodyAnimator.SetBool("isMoving", isMoving);
    }

    public void SetLegAnimation(bool isMoving)
    {
        frontLegAnimator.SetBool("isMoving", isMoving);
        backLegAnimator.SetBool("isMoving", isMoving);
    }
}
