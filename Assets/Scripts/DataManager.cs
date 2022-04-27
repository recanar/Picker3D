using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public int highestLevel;
    private void Start()
    {
        LoadData();
    }
    public void IncreaseLevel()
    {
        highestLevel++;
        PlayerData playerData = new PlayerData(highestLevel);
        SaveData(playerData);
    }

    [System.Serializable]
    public class PlayerData
    {
        public int _Level;

        public PlayerData(int level)
        {
            _Level = level;
        }
    }
    
    public void SaveData(PlayerData playerData)
    {
        string json = JsonUtility.ToJson(playerData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {   
            string json = File.ReadAllText(path);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);

            highestLevel= playerData._Level;
        }
    }
}
