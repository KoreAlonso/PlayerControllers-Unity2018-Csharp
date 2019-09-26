using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInputs : MonoBehaviour
{
    float vertical;
    float horizontal;
    PlayerController playerController;

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        executeMovement();
    }

    private void Update()
    {
        getInputs();    
    }

    //metodo que ejecuta el movimiento segun las entradas
    void executeMovement()
    {
        playerController.rotationPlayer(horizontal);

        if (horizontal != 0)
        {
            if (vertical < 0)
            {
                playerController.sitMovement(horizontal);
            }
            else
            {
                playerController.horizontalMovement(horizontal);
            }
        }
        else
        {
            playerController.idleMovement();
        }

        if (vertical > 0)
        {
            playerController.jumpMovement(vertical);
        }

        if (Input.GetKeyUp(KeyCode.S))
                {
                    playerController.stopSit();
                }

    }
    
    //obtener entradas
    void getInputs()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }
}
