using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Controlador de escenas
public class GameManager : MonoBehaviour {
    
    Image canvasFade;
    Canvas canvasMenu;
  
    void Awake()
    {
        canvasMenu = GameObject.FindGameObjectWithTag("CanvasMenu").GetComponent<Canvas>();  
        canvasFade = GameObject.FindGameObjectWithTag("CanvasFade").GetComponentInChildren<Image>();
    }

    
    private void Start()
    {
        canvasFade.enabled = false;
        canvasMenu.enabled = true;
    }
    
    //Metodos encargados de cambio entre escenas
    public void sceneRigidbody2D()
    {
        canvasFade.enabled = true;
        canvasMenu.enabled = false;
        fade();
    //encargado de cargar la escena tras el fundido de imagen.
        Invoke("rigidbody2d", 1.5f);
    }
    public void sceneRigidbody3D()
    {
        canvasFade.enabled = true;
        canvasMenu.enabled = false;
        fade();
        Invoke("rigidbody3d", 1.5f);
    }
    public void sceneWheel()
    {
        canvasFade.enabled = true;
        canvasMenu.enabled = false;
        fade();
        Invoke("wheelCollider", 1.5f);
    }
    public void sceneCharacter()
    {
        canvasFade.enabled = true;
        canvasMenu.enabled = false;
        fade();
        Invoke("characterController", 1.5f);
    }

    //Metodos para cargar escenas
    public void rigidbody2d()
    {
       
        SceneManager.LoadScene("2DRigidbodyController");
    }
    public void rigidbody3d()
    {
    
        SceneManager.LoadScene("3DRigidbody");
    }

    public void wheelCollider()
    {
        
        SceneManager.LoadScene("WheelCollider");
    }

    public void characterController()
    {
        
        SceneManager.LoadScene("CharacterController");
    }

    //Fundido de imagen
    void fade()
    {    
        canvasFade.CrossFadeColor(Color.black, 1.5f, true, true);
    }
  
} 

