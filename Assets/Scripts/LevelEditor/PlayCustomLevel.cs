using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayCustomLevel : MonoBehaviour
{
    [SerializeField]private GameObject player;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private Button startGame;
    [SerializeField] private GameObject playCanvas;
    private void Start()
    {
        startGame.onClick.AddListener(StartGame);
    }
    void StartGame()
    {
        GameObject.Find("Menu").SetActive(false);
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        mainCamera = GameObject.Find("Main Camera");
        mainCamera.GetComponent<CameraController>().enabled = false;
        mainCamera.GetComponent<CameraOffSet>().enabled = true;
        playCanvas.SetActive(true);
    }
}
