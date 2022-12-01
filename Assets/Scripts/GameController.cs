using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]

public class GameController : MonoBehaviour
{
    public static GameController _GameController;
    public bool gameRunning;
    public Canvas pauseMen;
    public int esc = 0;
    
    
    
    // Start is called before the first frame update
    void Start()

    {
        gameRunning = true;
        pauseMen = GameObject.Find("CanvasPause").GetComponent<Canvas>();
        pauseMen.enabled = false;
        // ButtonResume = GameObject.FindGameObjectWithTag("Resume").GetComponent<Button>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            esc++;
           
        }
        if (esc == 0 )
        {
            gameRunning = true;
            

        }
        
        if (esc == 1 )
        {
            gameRunning = false;
            
        }
        if (esc > 1)
        {
            esc = 0;
            gameRunning = true;
        }
        
        
        if (gameRunning == false)
        {
            // Debug.Log("Game pause");
            Time.timeScale = 0f;
            pauseMen = GameObject.Find("CanvasPause").GetComponent<Canvas>();
            pauseMen.enabled = true;
            
        }
        else
        {
            // Debug.Log("Game running");
            Time.timeScale = 1f;
            pauseMen = GameObject.Find("CanvasPause").GetComponent<Canvas>();
            pauseMen.enabled = false;
            // ChangeRunnningState();
        }
       

    }
    
    

    public bool IsGameRunning()
    {
        return gameRunning;
    }
    
}
