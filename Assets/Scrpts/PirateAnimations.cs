using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateAnimations : MonoBehaviour {

    public Animator animator;




    void FixedUpdate () {
        

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
       


        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("isAngry");

        }
        else
        {
            animator.SetTrigger("isntAngry");

        }
        if (Input.GetKey(KeyCode.LeftShift) & vertical > -0.4f) {
            animator.SetBool("isRun",true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }

        animator.SetFloat ("Vertical", vertical);
        animator.SetFloat ("Horizontal", horizontal);
    }
}




/*  Estube barajando distintas posibilidades a partir de estas dos, y ninguna obtuvo resultado
 *  hasta que hioce uso del parametro Trigger. 
 *  
 *  
    if(Input.GetKeyDown(KeyCode.Q){

    animator.SetBool("bool", true);
    }
    else
    { 
    animator.SetBool("bool", false);
    }

    -----------------------------------
    
    variable = Input.GetKeyDown(KeyCode.Q);
    animator.SetBool("bool", variable);


    */
