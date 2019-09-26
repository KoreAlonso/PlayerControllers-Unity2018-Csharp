using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script para ejecutar movimiento segun los inputs
public class ShipInputs : MonoBehaviour {

    static float  vertical;
    static float  horizontal;
    ShipMovement shipMovement;
    

    void Start () {
        shipMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<ShipMovement>();
    }

    void FixedUpdate () {
        forwardTranslate();
        horizontalRotate();
        verticalMovement();
	}
     void Update()
    {
        
        obtainInputs();
    }

    void obtainInputs()
    {
        vertical = Input.GetAxis("Mouse Y");
        horizontal = Input.GetAxis("Mouse X");
    }

    //metodos encargados de devolver un valor float (este caso axis) en otros script
   public static float getVertical()
    {
        return vertical;
    }
    public static float  getHorizontal()
    {
        return horizontal;
    }

    //asigno los inputs a los metodos correspondientes.
    void horizontalRotate() 
    {
      if(horizontal != 0)
        {
            shipMovement.rotateYShip();
            
        }
    }
    void forwardTranslate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            shipMovement.forwardForce();
        }
    }

    void verticalMovement()
    {
        if(vertical !=0)
        {
            shipMovement.yForce();
        }
    }
}

