using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public int currentLevel;
    private void Awake()
    {
        LoadData();
    }
    public void IncreaseLevel()
    {
        currentLevel++;
        PlayerData playerData = new PlayerData(currentLevel);
        SaveData(playerData);
    }
    public void ChangeLevel(int level)
    {
        PlayerData playerData = new PlayerData(level);
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

            currentLevel= playerData._Level;
        }
    }
}
