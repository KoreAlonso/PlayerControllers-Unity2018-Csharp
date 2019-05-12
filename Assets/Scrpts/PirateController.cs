using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateController : MonoBehaviour {

    public float velocity = 3;
    public float rotate = 55f;
    public float gravity = 0.2f;
    public float jumpForce = 5f;
    public float velocityRun = 4.7f;


    public CharacterController characterController;
    Vector3 direccion = Vector3.zero;

   void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update () {

        if (characterController.isGrounded) {

            float movement = Input.GetAxis("Vertical");
            direccion = new Vector3(0, 0, movement);
            direccion = transform.TransformDirection(direccion);
            direccion *= velocity;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                direccion *= velocityRun;
                
            }

         if (Input.GetButton ("Jump")) 
         {
                direccion.y = jumpForce;      
         }

        }
        else
        {
            direccion.y -= gravity;

        }
        transform.Rotate(0, rotate  * Input.GetAxis("Horizontal") * Time.deltaTime, 0);
        characterController.Move(direccion * Time.deltaTime);
	}
 
}
