using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
/* ************************************************************ */
public Rigidbody2D playerRb;
// public static PlayerMove Instance;
public float speed = 3.5f;
public float  jumpSpeed = 250f;
public bool isGrounded = true;
private bool flew = false;
public Animator PlayerAnim;
public float x;
public float y;


/* ************************************************************ */
    
    void Start()
    {
        if (GameStatus._GameStatus.LoadGame == 1)
        {
            x = GameStatus._GameStatus.PositionX;
            y = GameStatus._GameStatus.PositionY;
            transform.position = new Vector2(x, y);
        }

    }
    
void Update(){
    playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRb.velocity.y);
    
    // if (playerRb.transform.position.y < -50f)
    // {
    //     Debug.Log("Triggered by Enemy");
    //     // SubstractHealth();
    //     // transform.position = new Vector3(x,y,z);
    // }
    
    
    if (Input.GetAxis("Horizontal") == 0) // Si no se mueve then
    {
        PlayerAnim.SetBool("isWalking",false); //Accediendo al Elemento y no camina
    }
    else if (Input.GetAxis("Horizontal") < 0)
    {
        PlayerAnim.SetBool("isWalking",true); //Accediendo al Elemento y camina
        GetComponent<SpriteRenderer>().flipX = true; 
    }
    else if (Input.GetAxis("Horizontal") > 0)
    {
        PlayerAnim.SetBool("isWalking",true); //Accediendo al Elemento y camina
        GetComponent<SpriteRenderer>().flipX = false; 
    }
    if ((!isGrounded && !flew) || (!isGrounded && flew) )
    {
        PlayerAnim.SetBool("Jump",true);
    }
    else
    {
        PlayerAnim.SetBool("Jump",false);
    }
    
    if (Input.GetKeyDown(KeyCode.Space))
    {
        if (isGrounded)
        {
            Jump();
            flew = true;
        }else if (flew)
        {
            Jump();
            flew = false;
        }
    }
}

    private void Jump()
    {
        GetComponent<AudioSource>().Play();
        playerRb.AddForce(Vector2.up * jumpSpeed);
        isGrounded = false;
    }

    private void  OnCollisionEnter2D (Collision2D collision )
    {
        if (collision.gameObject.CompareTag("Ground")) // Si la colision del objeto del juego con el tag llamado "Ground" existe, entonces
        {
            isGrounded = true;
            // PlayerAnim.SetBool("IsGrounded",false);
            flew = false;
        }
            
    }

}
