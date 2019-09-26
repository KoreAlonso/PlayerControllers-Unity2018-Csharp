using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTaxi : MonoBehaviour {

    WheelCollider colliderFL, colliderFR, colliderBL, colliderBR;
    Transform wheelFL, wheelFR;
    InputManager inputManager;
    float velocity = 380;
    float maxRotate = 35;
    float brakeForce = 170;


    void Awake()
    {
        inputManager = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>();
        colliderFL = GameObject.FindGameObjectWithTag("ColliderFL").GetComponent<WheelCollider>();
        colliderFR = GameObject.FindGameObjectWithTag("ColliderFR").GetComponent<WheelCollider>();

        wheelFL = GameObject.FindGameObjectWithTag("WheelFL").GetComponent<Transform>();
        wheelFR = GameObject.FindGameObjectWithTag("WheelFR").GetComponent<Transform>();
    }

    //Movimiento por getAxis. (velocity esta en negativo ya que los gizmos del asset no estaban en los ejes correctos de Unity) 
    public void movement()
    {
        colliderFL.brakeTorque = 0;
        colliderFR.brakeTorque = 0;
        colliderFL.motorTorque = -velocity * inputManager.getVertical();
        colliderFR.motorTorque = -velocity * inputManager.getVertical();
        
    }
    
    //Rotacion de los wheelCollider. Se llama al metodo encargado de rotar la maya
    public void rotation()
    {
        colliderFL.steerAngle = maxRotate * inputManager.getHorizontal();
        colliderFR.steerAngle = maxRotate * inputManager.getHorizontal();
        rotationMesh();
    }
    //Rotacion de la maya
     void rotationMesh()
    {
        wheelFL.localEulerAngles = new Vector3(wheelFL.localEulerAngles.x, colliderFL.steerAngle - wheelFL.localEulerAngles.z, wheelFL.localEulerAngles.z);
        wheelFR.localEulerAngles = new Vector3(wheelFR.localEulerAngles.x, colliderFR.steerAngle - wheelFR.localEulerAngles.z, wheelFR.localEulerAngles.z);

    }
    //Frenar
    public void breakMovement()
    {
       
            colliderFL.brakeTorque = brakeForce;
            colliderFR.brakeTorque = brakeForce;
        
    }


}
