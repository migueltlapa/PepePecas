using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dnachona : MonoBehaviour
{
    
    public SceneChanger changeScene;
    
    private void  OnCollisionEnter2D (Collision2D collision )
    {
        if (collision.gameObject.tag == "Player")
        {
            changeScene.ChangeSceneTo("Next_Level");
           
        }
        
    }
}
