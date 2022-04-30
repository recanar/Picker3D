using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LevelEditor : MonoBehaviour
{
    private Vector3 whereToAdd = Vector3.zero;//where to add platform,stage checker
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject stagePrefab;
    [SerializeField] private GameObject pointPrefab;

    [SerializeField] private GameObject platforms;

    [SerializeField] private Button addPlatformButton;
    [SerializeField] private Button addStageButton;
    [SerializeField] private TMP_InputField requiredBallText;
    [SerializeField] private Button deletePlatformButton;

    [SerializeField] private Button addPointButton;


    RaycastHit hit;
    GameObject createdPoint;
    bool isPointAddSelected;
    void Start()
    {
        requiredBallText.text = "1";
        addPlatformButton.onClick.AddListener(AddPlatform);
        addStageButton.onClick.AddListener(AddStage);
        deletePlatformButton.onClick.AddListener(DeleteLastPlatform);
        addPointButton.onClick.AddListener(AddPoint);
    }
    void Update()
    {
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100);
        if(createdPoint != null && isPointAddSelected)
        {
            createdPoint.transform.position = hit.point+Vector3.up/4;
        }
        if (isPointAddSelected && Input.GetMouseButtonDown(0))
        {
            isPointAddSelected = false;
            createdPoint.GetComponent<SphereCollider>().enabled = true;
        }
    }
    private void AddPlatform()
    {
        Instantiate(platformPrefab, whereToAdd, Quaternion.identity, platforms.transform);
        whereToAdd += Vector3.forward * 10;
    }
    private void AddStage()
    {
        int requiredBallForPassStage;
        requiredBallForPassStage=Convert.ToInt32(requiredBallText.text);
        GameObject stage = Instantiate(stagePrefab, whereToAdd, Quaternion.identity, platforms.transform);
        stage.GetComponent<StageCheck>().RequiredBall = requiredBallForPassStage;

        whereToAdd += Vector3.forward * 10;
    }
    private void AddPoint()
    {
        createdPoint= Instantiate(pointPrefab, hit.point, Quaternion.identity);
        createdPoint.GetComponent<SphereCollider>().enabled = false;
        isPointAddSelected= true;
    }
    private void DeleteLastPlatform()
    {
        if (platforms.transform.childCount>0)
        {
            Destroy(platforms.transform.GetChild(platforms.transform.childCount - 1).gameObject);
            whereToAdd -= Vector3.forward * 10;
        }
    }
}
