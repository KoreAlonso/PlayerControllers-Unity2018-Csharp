using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float hForce = 41f;
    public float hJumpForce = 15f;
    public float hSitForce = 26.7f;
    public float vForce = 275f;
    public float angleRotation = 180f;


    public bool isGrounded;
    bool lookLeft = true;
    Rigidbody2D player;
    Transform playerTrans;
    PlayerAnimations playerAnimations;


    void Awake()
    {
        player = this.GetComponent<Rigidbody2D>();
        playerTrans = this.GetComponent<Transform>();
        playerAnimations = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimations>();
    }

    //en idel solo se llama a su animacion. 
    public void idleMovement()
    {
        playerAnimations.idleAnimation();

    }


    public void horizontalMovement(float horizontal)
    {
        //si esta en el suelo,, añade fuerza en X * fuerza * por el axis horizontal 
        if (isGrounded)
        {
            player.AddRelativeForce(transform.right * hForce * horizontal, ForceMode2D.Impulse);
            playerAnimations.horizontalAnimation();

        }
        //si no lo esta, se multiplica por la fuerza de salto 
        else
        {
            
            player.AddRelativeForce(transform.right * hJumpForce * horizontal, ForceMode2D.Impulse);
            
        }

    }


    public void sitMovement(float horizontal)
    {
        //si esta en el suelo, la fuerza de movimiento disminuye, se añade la animacion correspondiente. 
        if (isGrounded)
        {
            player.AddRelativeForce(transform.right * hSitForce * horizontal, ForceMode2D.Impulse);
            playerAnimations.sitAnimation();

        }
    }

    //metodo para dejar de estar en animacion de sit.
    public void stopSit()
    {
        playerAnimations.isntSitAnimation();
    }

    
    public void jumpMovement(float vertical)
    {
        //si estoy en el suelo, fuerza en eje Y, se ejecuta animacion y el suelo en falso para no poder saltar más.
        if (isGrounded)
        {
            player.AddRelativeForce(transform.up * vForce * vertical, ForceMode2D.Impulse);
            playerAnimations.jumpAnimation();
            isGrounded = false;

        }

    }

    //encargado de girar el sprite
    public void rotationPlayer(float horizontal)
    {
        //solo si voy a la der. y miro a la izq. o si voy a la izq. y no miro a la izq. 
        if (horizontal > 0 && lookLeft || horizontal < 0 && !lookLeft)
        {
            //se pone el bool encargado de saber hacia donde mira a false ya que al comienzo esta en true,
            //pero en cuanto el axis no corresponde con la direccion, este pasa a false
            lookLeft = !lookLeft;
            //se crea vector3 (transform local del player) y en eje x se * -1 para girarlo. Por ultimo al transform se le asigna ese valor
            Vector3 scale = playerTrans.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    //metodos encargados de saber si estoy o no en el suelo. 

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
