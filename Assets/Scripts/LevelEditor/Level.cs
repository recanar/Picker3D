using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Level:MonoBehaviour
{
    [SerializeField] private GameObject platforms;
    [SerializeField] private GameObject points;
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject point;
    [SerializeField] private GameObject stage;

    public List<GameObject> objectPrefabs = new List<GameObject>();
    public List<Vector3> objectPositions = new List<Vector3>();

    [SerializeField] private Button saveButton;
    [SerializeField] private Button loadButton;

    private void Start()
    {
        saveButton.onClick.AddListener(SaveLevel);
        loadButton.onClick.AddListener(LoadLevel);
    }
    private void SaveLevel()
    {
        for (int i = 0; i < platforms.transform.childCount; i++)
        {
            if (platforms.transform.GetChild(i).gameObject.CompareTag("Platform"))
            {
                objectPrefabs.Add(platform);
                objectPositions.Add(platforms.transform.GetChild(i).position);
            }
            if (platforms.transform.GetChild(i).gameObject.CompareTag("Stage"))
            {
                objectPrefabs.Add(stage);
                objectPositions.Add(platforms.transform.GetChild(i).position);
            }
        }//add list all level objects on the scene
        for (int i = 0; i < points.transform.childCount; i++)
        {
            if (points.transform.GetChild(i).gameObject.CompareTag("Point"))
            {
                objectPrefabs.Add(point);
                objectPositions.Add(points.transform.GetChild(i).position);
            }
        }
        LevelObjects levelObjects = new LevelObjects(objectPrefabs, objectPositions);
        SaveData(levelObjects);
    }
    private void LoadLevel()
    {
        for (int i = 0; i < platforms.transform.childCount; i++)
        {
            Destroy(platforms.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < points.transform.childCount; i++)
        {
            Destroy(points.transform.GetChild(i).gameObject);
        }
        LoadData();
        for (int i = 0; i < objectPrefabs.Count; i++)
        {
            if (objectPrefabs[i].CompareTag("Platform"))
            {
                Instantiate(objectPrefabs[i], objectPositions[i], Quaternion.identity, platforms.transform);
            }
            if (objectPrefabs[i].CompareTag("Stage"))
            {
                Instantiate(objectPrefabs[i], objectPositions[i], Quaternion.identity, platforms.transform);
            }
            if (objectPrefabs[i].CompareTag("Point"))
            {
                Instantiate(objectPrefabs[i], objectPositions[i], Quaternion.identity, points.transform);
            }
        }
    }
    
    [System.Serializable]
    public class LevelObjects
    {
        public List<GameObject> objectPrefabs = new List<GameObject>();
        public List<Vector3> objectPositions = new List<Vector3>();

        public LevelObjects(List<GameObject> objectPrefabs,List<Vector3> objectPositions)
        {
            this.objectPrefabs = objectPrefabs;
            this.objectPositions = objectPositions;
        }
    }
    public void SaveData(LevelObjects levelObjects)
    {
        string json = JsonUtility.ToJson(levelObjects);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            LevelObjects levelData = JsonUtility.FromJson<LevelObjects>(json);

            objectPrefabs = levelData.objectPrefabs;
            objectPositions = levelData.objectPositions;
        }
    }
}
