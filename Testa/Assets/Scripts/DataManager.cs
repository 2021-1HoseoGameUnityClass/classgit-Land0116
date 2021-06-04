using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using System.Runtime.Serialization.Formatters.Binary;

public class DataManager : MonoBehaviour
{
    private static DataManager _instance = null;
    
    public static DataManager instance { get { return _instance; } }

    public int playerHP = 3;
    public string sceneName = "SampleScene";


    private void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update


    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveData()
    {
        SaveData saveData = new SaveData();
        saveData.currentScene = sceneName;
        saveData.playerHP = playerHP;

        FileStream fileStream = File.Create(Application.persistentDataPath + "/save.dat");

        Debug.Log("历厘 颇老 积己");

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, saveData);
        fileStream.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            FileStream fileStream = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);

            if(fileStream != null && fileStream.Length > 0)
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                SaveData saveData = (SaveData)binaryFormatter.Deserialize(fileStream);
                playerHP = saveData.playerHP;
                UImanager.instance.PlayerHP();
                sceneName = saveData.currentScene;

                fileStream.Close();
            }
        }
    }
}
