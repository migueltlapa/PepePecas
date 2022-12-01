using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collectable : MonoBehaviour
{
    public static Collectable _Collectable;
    public static int cornCollectable = 0;
    public ParticleSystem collectaParticleSystem;
    public AudioSource collectableAudio;
    public Text CollectableText;
    public int collectableToGS;
    public int collectableRecordToGS;
    
    void Start()
    {
        collectableToGS= GameStatus._GameStatus.collectablesRaw;
        collectableRecordToGS = GameStatus._GameStatus.collectablesRecord;
        
        if (SceneManager.GetActiveScene().name == "First_level")
        {
            if (GameStatus._GameStatus.LoadGame == 1)
            {
                cornCollectable = GameStatus._GameStatus.collectablesRaw;
            }
            else
            {
                cornCollectable = 0;
            }
        }
        else
        {
            cornCollectable = GameStatus._GameStatus.collectablesRaw;
            // changeNumberOfCollectables();
        }
        collectableAudio = GetComponentInParent<AudioSource>();
        CollectableText = GameObject.Find("CollectableContador (number)").GetComponent<Text>();
        collectaParticleSystem = GameObject.Find("ParticlesCollectable").GetComponent<ParticleSystem>();

        
        NotificationCenter.DefaultCenter().AddObserver(this,"IncrementCollectable");
        NotificationCenter.DefaultCenter().AddObserver(this,"Dead");
        
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Player")
        {
            collectaParticleSystem.transform.position = transform.position; // las particulas se colocan en donde estan los elotes
            collectaParticleSystem.Play();
            collectableAudio.Play();
            gameObject.SetActive(false);
            cornCollectable++;
            NotificationCenter.DefaultCenter().PostNotification(this,"IncrementCollectable");
            changeNumberOfCollectables();

        }
        
    }
    public void IncrementCollectable (Notification notification)
    {
         
        //  collectableToGS = cornCollectable;
        // // GameStatus._GameStatus.Save();
        //
        //
        // if (collectableRecordToGS <= cornCollectable)
        // {
        //     // Debug.Log("Se ha superado el record!! " + cornCollectable + " anterior: " + GameStatus._GameStatus.collectablesRecord);
        //     
        //     GameStatus._GameStatus.collectablesRaw = cornCollectable;          
        //     collectableRecordToGS = cornCollectable;
        //     // GameStatus._GameStatus.Save();
        // }
    }

    private void changeNumberOfCollectables()
    {
        CollectableText.text = cornCollectable.ToString();
    }

    
}
