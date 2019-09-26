using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controlador de animaciones
public class PirateAnimations : MonoBehaviour {

     Animator animator;

     void Awake()
    {
        animator = GetComponent<Animator>();   
    }

    void Update () {

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        //se asignan los axis a los parametros correspondientes. BlendTree se encarga de ejecutar las animaciones segun la posicion de los axis
        animator.SetFloat ("Vertical", vertical);
        animator.SetFloat ("Horizontal", horizontal);

        //Encargado de hacer animacion de correr
        if (Input.GetKey(KeyCode.LeftShift)  && vertical > 0.4f) {
            animator.SetBool("isRun",true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }

        //encargado de hacer animacion de disparo.
        if (Input.GetKey(KeyCode.Q) && vertical == 0)
        {
            animator.SetTrigger("isAngry");

        }
        else
        {
            animator.SetTrigger("isntAngry");

        }
  
    }
}





