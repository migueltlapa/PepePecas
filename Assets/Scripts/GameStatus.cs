using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;


public class GameStatus : MonoBehaviour
{
    public static GameStatus _GameStatus;
    
    private string pathData;
    public int tacos = 3;
    public int collectablesRaw;
    public int collectablesRecord ;
    public Text TacosLive;
    public Text score;
    public Text collectablesRawText;
    public string nameScene;
    public float PositionX;
    public float PositionY;
    public int LoadGame;
    
   
    
    void Awake()
    {
        // Debug.Log(Application.persistentDataPath);
        pathData = Application.persistentDataPath + "/data.dat";
        
        if (!_GameStatus)
        {
            _GameStatus = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(_GameStatus != this)
        {
            Destroy(gameObject); 
        }
        
    }
    
    void Start()
    {
        Load();
        
        
    }
    
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Next_Level")
        {
            TacosLive = GameObject.Find("HearthContador(number)").GetComponent<Text>();
            TacosLive.text = tacos.ToString();
        }
        else if (SceneManager.GetActiveScene().name == "LoseScene" || SceneManager.GetActiveScene().name == "WinScene")
        {
            score = GameObject.Find("CollectableNumber").GetComponent<Text>();
            collectablesRawText = GameObject.Find("BestScore").GetComponent<Text>();
            
            score.text = collectablesRaw.ToString();
            collectablesRawText.text = collectablesRecord.ToString();
            // Debug.Log("Estyo en lose");
        }
        
        
        
        
        
    }
    
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(pathData);

        SaveData data = new SaveData( collectablesRaw, tacos, collectablesRecord, nameScene, PositionX,PositionY,LoadGame);
        
        bf.Serialize(file, data);
        
        file.Close();
    }
    
    void Load()
    {
        
        if (File.Exists(pathData))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(pathData,FileMode.Open);

            SaveData data = (SaveData) bf.Deserialize(file);

            collectablesRaw = data.collectablesRaw;
            tacos = data.tacos;
            collectablesRecord = data.collectablesRecord;
            nameScene = data.nameScene;
            PositionX = data.PositionX;
            PositionY = data.PositionY;
            LoadGame = data.LoadGame;
            
            file.Close();
        }
        else
        {
            collectablesRaw = 0;
            tacos = 3;
        }

    }
    
    [Serializable]
    class SaveData
    {
        public int collectablesRaw;
        public int tacos;
        public int collectablesRecord;
        public string nameScene;
        public float PositionX;
        public float PositionY;
        public int LoadGame;
        
        public SaveData
        (
         int collectablesRaw,
         int tacos,
         int collectablesRecord,
         string nameScene,
         float PositionX,
         float PositionY,
         int LoadGame 
        )
        {
            this.collectablesRaw = collectablesRaw;
            this.tacos = tacos;
            this.collectablesRecord = collectablesRecord;
            this.nameScene = nameScene;
            this.PositionX = PositionX;
            this.PositionY = PositionY;
            this.LoadGame = LoadGame;

        }
        
    }

}
