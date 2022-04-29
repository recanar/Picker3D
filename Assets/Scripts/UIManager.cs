using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region UI Variables
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI pointText;
    [SerializeField] private TextMeshProUGUI tapToStartText;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject nextLevelMenu;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button nextLevelButton;
    #endregion
    GameManager gameManager;
    DataManager dataManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
        restartButton.onClick.AddListener(RestartScene);
        nextLevelButton.onClick.AddListener(NextLevel);
    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = "Point:" +gameManager.point;//For debug
        GameStartCheck();//UI for explain how to start game
        LevelInfo();
        GameOverMenu();
        LevelCompleteMenu();
    }


    private void GameStartCheck()
    {
        if (gameManager.currentState != State.WaitingTap)
        {
            tapToStartText.gameObject.SetActive(false);
        }
    }
    private void LevelInfo()
    {
        if (gameManager.currentState == State.Playing)
        {
            levelText.text = "Level:" + dataManager.highestLevel + "-" + gameManager.levelStage;
        }
    }
    void GameOverMenu()
    {
        if (gameManager.currentState==State.GameOver)
        {
            gameOverMenu.SetActive(true);
        }
    }
    void LevelCompleteMenu()
    {
        if (gameManager.currentState==State.Win)
        {
            levelText.text = "Finished";
            nextLevelMenu.gameObject.SetActive(true);
        }
    }
    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void NextLevel()
    {
        dataManager.IncreaseLevel();//increase level then save current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
