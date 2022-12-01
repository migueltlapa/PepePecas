using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    private GameController gameControl;
    public bool hola = true ;
    
    // Start is called before the first frame update
    void Start()
    {
        gameControl = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResumeGame()
    {
        Debug.Log("click");
        gameControl.esc++;
        Debug.Log("click  " + gameControl.gameRunning);
    }
}
