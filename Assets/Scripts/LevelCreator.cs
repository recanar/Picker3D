using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{

    [SerializeField] GameObject stages;
    [SerializeField] GameObject platforms;
    [SerializeField] GameObject point; 

    protected Vector3 whereToAdd=Vector3.zero;
    [SerializeField] GameObject platformPrefab;
    [SerializeField] GameObject stagePrefab;
    void Start()
    {
        CreateBasicLevel();
    }
    private void CreateBasicLevel()
    {
        AddPlatform(10);
        AddStage(0);
        AddPlatform(10);
        AddStage(0);
        AddPlatform(10);
        AddStage(0);
    }

    private void AddPlatform()
    {
        Instantiate(platformPrefab,whereToAdd,Quaternion.identity,platforms.transform);
        whereToAdd += Vector3.forward * 10;
    }
    private void AddPlatform(int platformLength)
    {
        for (int i = 0; i < platformLength; i++)
        {
            Instantiate(platformPrefab, whereToAdd, Quaternion.identity, platforms.transform);
            whereToAdd += Vector3.forward * 10;
        }
    }
    private void AddStage(int requiredBallForPassStage)
    {
        Instantiate(stagePrefab, whereToAdd, Quaternion.identity, stages.transform);
        whereToAdd += Vector3.forward * 10;
    }
}
