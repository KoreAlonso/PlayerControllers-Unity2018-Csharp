using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    float vertical;
    float horizontal;
    MovementTaxi movementTaxi;

     void Awake() 
    {
        movementTaxi = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementTaxi>();
    }

    void Update () {

        getAxis();
        taxiAdvance();
        wheelRotation();
        brakeAdvance();
	}

    //Llamo a los métodos del script MovementTaxi
    void taxiAdvance()
    {
        movementTaxi.movement();
    }
    void wheelRotation()
    {
        movementTaxi.rotation();
    }
    void brakeAdvance()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementTaxi.breakMovement();
        }  
    }


   public void getAxis()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
    }

    //Metodos para obtener los Axis desde otros scripts. 
    public float getVertical()
    {
        return vertical;
    }
     public float getHorizontal()
    {
        return horizontal;
    }

}
