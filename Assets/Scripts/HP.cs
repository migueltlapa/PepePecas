using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    public int hp ;
    bool hasCooldown = false;
    public SceneChanger changeScene;
    public Rigidbody2D pepe;
    private Notification notification;
    public Text tacosText;
    private float x = 5.7f;
    private float y = 2.2f;
   

    private int tacosLoad;

    void Start()
    {
        
        
        if (SceneManager.GetActiveScene().name == "First_level")
        {
            if (GameStatus._GameStatus.LoadGame == 1)
            {
                hp = GameStatus._GameStatus.tacos;
            }
            else
            {
                hp = 3;
            }
            
        }
        else
        {
            hp = GameStatus._GameStatus.tacos;
        }
        
        NotificationCenter.DefaultCenter().AddObserver(this,"Dead");
        NotificationCenter.DefaultCenter().AddObserver(this,"IncrementCollectable");
        EmptyHearts();
    }

    void Dead(Notification notification)
    {
        // Debug.Log( "Vida aneterior: " + GameStatus._GameStatus.tacos);
        
      
        // GameStatus._GameStatus.collectablesRaw = Collectable.cornCollectable;
        
        if (Collectable.cornCollectable > GameStatus._GameStatus.collectablesRecord )
        {
             GameStatus._GameStatus.collectablesRecord = Collectable.cornCollectable;
             GameStatus._GameStatus.collectablesRaw = Collectable.cornCollectable ;
        }
        else
        {
             GameStatus._GameStatus.collectablesRaw = Collectable.cornCollectable ;
            
        }
        Debug.Log("Elotes: " + Collectable.cornCollectable + "Elotes collect" + GameStatus._GameStatus.collectablesRaw + "Elotes record" + GameStatus._GameStatus.collectablesRecord);
        GameStatus._GameStatus.tacos = hp;
        GameStatus._GameStatus.LoadGame = 0;
        GameStatus._GameStatus.Save();
        
        
        
    }
    void Update()
    {
        if (pepe.transform.position.y <= -30f )
        {
            SubstractHealth();
            transform.position = new Vector2(x,y);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (GetComponent<PlayerMove>().isGrounded)
            {
                SubstractHealth();
            }
        }
    }
    
    public void SubstractHealth()
    {
        if (!hasCooldown)
        {
            if(hp > 0)
            {
                hp--;
                
                hasCooldown = true;
                StartCoroutine(Cooldown());
            }

            if(hp <= 0)
            {
                changeScene.ChangeSceneTo("LoseScene");
            }
            
            EmptyHearts();
            
        }
    }

    public void EmptyHearts()
    {
        tacosText = GameObject.Find("HearthContador(number)").GetComponent<Text>();
        tacosText.text = hp.ToString();
        NotificationCenter.DefaultCenter().PostNotification(this,"Dead");
        
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(.5f);
        hasCooldown = false;
        
        StopCoroutine(Cooldown());
    }    
    
    
    
}
