using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SaveFunction : MonoBehaviour
{
    
    // public int corn;
    public string level;
    public float PositionX;
    public float PositionY;
    
    void Start()
    {
         
       
        level = SceneManager.GetActiveScene().name;
        
        if (SceneManager.GetActiveScene().name == "First_level" || SceneManager.GetActiveScene().name == "Second_level")
        {
            PositionX = GameObject.Find("Player").transform.position.x;
            PositionY = GameObject.Find("Player").transform.position.y;
        }
       
    }
    

    public void SaveData()
    {
        if (Collectable.cornCollectable > GameStatus._GameStatus.collectablesRecord )
        {
            GameStatus._GameStatus.collectablesRecord = Collectable.cornCollectable;
            GameStatus._GameStatus.collectablesRaw = Collectable.cornCollectable ;
        }
        else
        {
            GameStatus._GameStatus.collectablesRaw = Collectable.cornCollectable ;
            
        }
        
        GameStatus._GameStatus.nameScene = level;
        if (SceneManager.GetActiveScene().name == "First_level" || SceneManager.GetActiveScene().name == "Second_level")
        {
            GameStatus._GameStatus.PositionX = PositionX;
            GameStatus._GameStatus.PositionY = PositionY;
        }
        GameStatus._GameStatus.Save();
        
        Debug.Log(GameStatus._GameStatus.tacos);
        Debug.Log(GameStatus._GameStatus.collectablesRaw);
        Debug.Log(GameStatus._GameStatus.nameScene);
        Debug.Log(GameStatus._GameStatus.PositionX);
        Debug.Log(GameStatus._GameStatus.PositionY);
        
    }
}
