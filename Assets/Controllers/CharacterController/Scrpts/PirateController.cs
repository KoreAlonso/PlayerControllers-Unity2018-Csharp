using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controlador de movimiento
public class PirateController : MonoBehaviour {

    public float velocity = 5;
    public float rotate = 90f;
    public float gravity = 0.8f;
    public float jumpForce = 25f;
    public float velocityRun = 5.4f;
    public float velocityWater = 0.5f;
    bool isOnWater = false;



    CharacterController characterController;
    Vector3 direccion = Vector3.zero;
  

   void Start()
    {
        characterController = GetComponent<CharacterController>();
           
    }

    void Update () {
        //si esta en el suelo
        if (characterController.isGrounded) {
            float movementHorizontal = Input.GetAxisRaw("Horizontal");            
            float movementVertical = Input.GetAxisRaw("Vertical");

            //se asignan los axis a los ejes correspondientes. Se cambian de espacio local, al global.
            direccion = new Vector3(movementHorizontal, 0, movementVertical);
            direccion = transform.TransformDirection(direccion); 
            
            //Velocidad en agua o tierra.
            if (isOnWater == true)
             {
                direccion /= velocityWater;
            }
            else
            {
                direccion *= velocity;
            }

            //velocidad de correr
            if (Input.GetKey(KeyCode.LeftShift) )
            {
                direccion *= velocityRun;
                
            }

            //velocidad de salto. Llamo al eje afectado.
            if (Input.GetButton("Jump") )
            {
                direccion.y = jumpForce;      
            }
        }
        //si no estoy en el suelo. 
        else
        {
            direccion.y -= gravity;

        }
     
        //se inicializa el movimiento con las direcciones y fuerzas anteriormente descritas.
        characterController.Move(direccion * Time.deltaTime);

        rotation();
	} 

    //Rotacion
    void rotation()
    {
        float rotateHorizontal = Input.GetAxis("Mouse X");
        transform.Rotate(0, rotate  * rotateHorizontal * Time.deltaTime, 0);

    }
    
    //metodos para saber cuando entro y salgo del agua
    void OnTriggerEnter(Collider other)
    {
        isOnWater = true;      

    }
   void OnTriggerExit(Collider other)
    {
        isOnWater = false;
    }
}
