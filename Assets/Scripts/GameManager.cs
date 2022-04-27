using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    #region UI Variables
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI pointText;
    [SerializeField] TextMeshProUGUI tapToStartText;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject nextLevelMenu;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button nextLevelButton;
    #endregion

    [SerializeField] private DataManager dataManager;


    [HideInInspector] public bool isGameStarted;
    [HideInInspector] public bool isPlaying;
    [HideInInspector] public bool isGameOver;

    [HideInInspector] public int point = 0;
    [HideInInspector] public int levelStage = 1;

    void Start()
    {
        restartButton.onClick.AddListener(RestartScene);
        nextLevelButton.onClick.AddListener(NextLevel);
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
    }
    void Update()
    {

        StartGame();//starts game with horizontal input
        GameStartCheck();//UI for explain how to start game

        LevelCompleteCheck();
        GameOverCheck();
        
        pointText.text = "Point:" + point;//For debug

    }

    private void GameStartCheck()
    {
        if (isGameStarted)
        {
            tapToStartText.gameObject.SetActive(false);
        }
    }

    private void StartGame()
    {
        
        if (!isGameStarted)
        {
            if (Input.GetAxis("Horizontal")>0.2|| Input.GetAxis("Horizontal") < -0.2)
            {
                isGameStarted = true;
                isPlaying = true;
            }
        }
    }

    void LevelCompleteCheck()
    {
        if (levelStage <= 3)
        {
            levelText.text = "Level:" + dataManager.highestLevel + "-" + levelStage;
        }
        else
        {
            levelText.text = "Finished";
            nextLevelMenu.gameObject.SetActive(true);
        }
    }
    void GameOverCheck()
    {
        if (isGameOver)
        {
            gameOverMenu.SetActive(true);
        }
    }
    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void NextLevel()
    {
        dataManager.IncreaseLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
