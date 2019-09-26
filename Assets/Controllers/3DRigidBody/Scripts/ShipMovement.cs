using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script de movimiento
public class ShipMovement : MonoBehaviour {

     float forwardVelocity = 100;
     float angleRotate = 1f;
     float upForce = 30;

    Rigidbody ship;
    Transform shipTransform;
    


    private void Awake()
    {
        ship = this.GetComponent<Rigidbody>();
        shipTransform = this.GetComponent<Transform>(); 
    }

    //Fuerza de aceleracion 
    public void forwardForce() 
    {   
        ship.AddForce(this.transform.forward * forwardVelocity, ForceMode.Acceleration);
    }

    //rotacion en eje Y dependiente del axis horizontal
    public void rotateYShip() //
    {
        if (ShipInputs.getHorizontal() > 0)
        {
          shipTransform.Rotate(0, angleRotate * ShipInputs.getHorizontal(), 0, Space.World);
        }
        if (ShipInputs.getHorizontal() < 0)
        {
           shipTransform.Rotate(0, -angleRotate  * -ShipInputs.getHorizontal(), 0, Space.World);
           
        }
    }

    //fuerza de aceleracion en eje Y dependiente de axis vertical

    public void yForce()
    {
        if (ShipInputs.getVertical() > 0)
        {

            ship.AddForce(this.transform.up * upForce * ShipInputs.getVertical(), ForceMode.Acceleration);

        }
        else if (ShipInputs.getVertical() < 0)
        {

            ship.AddForce(-this.transform.up * upForce * -ShipInputs.getVertical(), ForceMode.Acceleration);

        }
    }
}
