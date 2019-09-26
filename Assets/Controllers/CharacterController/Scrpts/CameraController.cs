using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controlador de camara
public class CameraController : MonoBehaviour {

    Camera  camera_c;
    Transform pirateController;
    Transform cameraPosition;

	// Use this for initialization
	void Awake () {
        camera_c = GetComponent < Camera > ();
        pirateController = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //empty vacio. Guarda la posicion.
        cameraPosition = GameObject.FindWithTag("CameraPosition").GetComponent<Transform>();

    }

    void LateUpdate () {
        followCamera();
	}

    void followCamera()
    {
        //se asigna la nueva posicion de la camara 
        camera_c.transform.position = cameraPosition.position;

        //se asigna el objeto enfocado
        camera_c.transform.LookAt( pirateController);

        //se asigna la misma rotacion a la camara que al personaje 
        camera_c.transform.rotation = pirateController.transform.rotation;
    }
}
