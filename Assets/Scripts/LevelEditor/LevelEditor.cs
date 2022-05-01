using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public enum EditStates
{
    Menu,
    AddingPoint,
    ChangingLocation,
    Deleting
}
public class LevelEditor : MonoBehaviour
{
    private Vector3 whereToAdd = Vector3.zero;//where to add platform,stage checker
    #region Prefabs
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject stagePrefab;
    [SerializeField] private GameObject pointPrefab;
    [SerializeField] private GameObject platforms;
    [SerializeField] private GameObject points;
    #endregion
    #region Buttons
    [SerializeField] private GameObject menu;
    [SerializeField] private Button addPlatformButton;
    [SerializeField] private Button addStageButton;
    [SerializeField] private TMP_InputField requiredBallText;
    [SerializeField] private Button deletePlatformButton;
    [SerializeField] private Button addPointButton;
    [SerializeField] private Button deleteButton;
    #endregion

    RaycastHit hit;
    GameObject createdPoint;
    EditStates currentEditState;
    void Start()
    {
        currentEditState = EditStates.Menu;
        #region ButtonListeners
        addPlatformButton.onClick.AddListener(AddPlatform);
        addStageButton.onClick.AddListener(AddStage);
        requiredBallText.text = "1";
        deletePlatformButton.onClick.AddListener(DeleteLastPlatform);
        addPointButton.onClick.AddListener(AddPoint);
        deleteButton.onClick.AddListener(StateDeleting);
        #endregion
    }
    void Update()
    {
        PointLocator();
        DestroyClickedObject();
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
        createdPoint= Instantiate(pointPrefab,points.transform);
        createdPoint.GetComponent<SphereCollider>().enabled = false;
        currentEditState= EditStates.AddingPoint;
        menu.SetActive(false);
    }
    private void PointLocator()
    {
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100);
        if (currentEditState==EditStates.AddingPoint)
        {
            createdPoint.transform.position = hit.point + Vector3.up / 4;//move point with cursor
        }
        if (currentEditState == EditStates.AddingPoint && Input.GetMouseButtonDown(0))
        {
            currentEditState = EditStates.Menu;
            createdPoint.GetComponent<SphereCollider>().enabled = true;
            menu.SetActive(true);
        }
    }
    private void DeleteLastPlatform()
    {
        if (platforms.transform.childCount>0)
        {
            Destroy(platforms.transform.GetChild(platforms.transform.childCount - 1).gameObject);
            whereToAdd -= Vector3.forward * 10;
        }
    }
    private void StateDeleting()
    {
        currentEditState = EditStates.Deleting;
        menu.SetActive(false);
    }
    private void DestroyClickedObject()
    {
        if (Input.GetMouseButtonDown(0)&& currentEditState==EditStates.Deleting)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)&&hit.collider.gameObject.CompareTag("Point"))
            {
                Destroy(hit.collider.gameObject);
                currentEditState=EditStates.Menu;
                menu.SetActive(true);
            }
        }
    }
}
