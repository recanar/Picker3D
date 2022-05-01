using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class HighestLevelChange : MonoBehaviour
{
    DataManager dataManager;

    [SerializeField] private Button levelChangeButton;
    [SerializeField] private TMP_InputField changeToLevelText;

    void Start()
    {
        levelChangeButton.onClick.AddListener(ChangeHighestLevel);
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
        changeToLevelText.text = (dataManager.currentLevel).ToString();
    }
    private void ChangeHighestLevel()
    {
        dataManager.ChangeLevel(Convert.ToInt32(changeToLevelText.text));//change highest level to input when change highest level button pressed
    }
}
