using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private GameObject platforms;
    [SerializeField] private GameObject points;
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject point;
    [SerializeField] private GameObject stage;

    public List<GameObject> objectPrefabs = new List<GameObject>();
    public List<Vector3> objectPositions = new List<Vector3>();
    public List<int> levelIndex=new List<int>();

    [SerializeField] private Button saveButton;
    [SerializeField] private Button loadButton;

    [SerializeField] private TMP_Dropdown dropdown;
    int selection;

    private void Start()
    {
        saveButton.onClick.AddListener(SaveLevel);
        loadButton.onClick.AddListener(LoadLevel);
    }
    private void Update()
    {
        selection = dropdown.GetComponent<TMP_Dropdown>().value;
    }
    private void SaveLevel()
    {
        for (int i = 0; i < platforms.transform.childCount; i++)
        {
            if (platforms.transform.GetChild(i).gameObject.CompareTag("Platform"))
            {
                objectPrefabs.Add(platform);
                objectPositions.Add(platforms.transform.GetChild(i).position);
                levelIndex.Add(selection);
            }
            if (platforms.transform.GetChild(i).gameObject.CompareTag("Stage"))
            {
                objectPrefabs.Add(stage);
                objectPositions.Add(platforms.transform.GetChild(i).position);
                levelIndex.Add(selection);
            }
        }//add list all level objects on the scene
        for (int i = 0; i < points.transform.childCount; i++)
        {
            if (points.transform.GetChild(i).gameObject.CompareTag("Point"))
            {
                objectPrefabs.Add(point);
                objectPositions.Add(points.transform.GetChild(i).position);
                levelIndex.Add(selection);
            }
        }
        LevelObjects levelObjects = new LevelObjects(objectPrefabs, objectPositions,levelIndex);
        SaveData(levelObjects);
    }
    private void LoadLevel()
    {
        for (int i = 0; i < platforms.transform.childCount; i++)
        {
            Destroy(platforms.transform.GetChild(i).gameObject);
        } //remove current level objects before load
        for (int i = 0; i < points.transform.childCount; i++)
        {
            Destroy(points.transform.GetChild(i).gameObject);
        }
        LoadData();
        for (int i = 0; i < objectPrefabs.Count; i++)
        {
            if (objectPrefabs[i].CompareTag("Platform")&&levelIndex[i]==selection)
            {
                Instantiate(objectPrefabs[i], objectPositions[i], Quaternion.identity, platforms.transform);
            }
            if (objectPrefabs[i].CompareTag("Stage") && levelIndex[i] == selection)
            {
                Instantiate(objectPrefabs[i], objectPositions[i], Quaternion.identity, platforms.transform);
            }
            if (objectPrefabs[i].CompareTag("Point") && levelIndex[i] == selection)
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
        public List<int> levelIndex = new List<int>();

        public LevelObjects(List<GameObject> objectPrefabs, List<Vector3> objectPositions,List<int> levelIndex)
        {
            this.objectPrefabs = objectPrefabs;
            this.objectPositions = objectPositions;
            this.levelIndex = levelIndex;
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
            levelIndex = levelData.levelIndex;
        }
    }
}
