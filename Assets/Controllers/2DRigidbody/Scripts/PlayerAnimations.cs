using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//encargado de administrar el animator
public class PlayerAnimations : MonoBehaviour
{

    Animator playerAnimator;

    void Awake()
    {

        playerAnimator = GetComponent<Animator>();

    }
    public void horizontalAnimation()
    {
        playerAnimator.SetBool("isMoving", true);
    }
    public void idleAnimation()
    {
        playerAnimator.SetBool("isMoving", false);
    }

    public void sitAnimation()
    {
        playerAnimator.SetBool("sit", true);
    }

    public void isntSitAnimation()
    {
        playerAnimator.SetBool("sit", false);
    }

    public void jumpAnimation()
    {
        playerAnimator.SetTrigger("jump");
    }



}


