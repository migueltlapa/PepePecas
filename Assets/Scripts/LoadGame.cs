using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
     
    public SceneChanger changeScene;
    public static LoadGame _LoadGame;

    public int loadPartida = 0;
    void Start()
    {
         
       
       
       
    }
    
    public void LoaadGame()
    {
        loadPartida = 1;
        loadPartida = GameStatus._GameStatus.LoadGame;
        GameStatus._GameStatus.Save();
        changeScene.ChangeSceneTo(GameStatus._GameStatus.nameScene);
        
        // Debug.Log(GameStatus._GameStatus.tacos);
        // Debug.Log(GameStatus._GameStatus.collectablesRaw);
        // Debug.Log(GameStatus._GameStatus.nameScene);
        // Debug.Log(GameStatus._GameStatus.PositionX);
        // Debug.Log(GameStatus._GameStatus.PositionY);
        
        
        
        
        
    }
    
}
