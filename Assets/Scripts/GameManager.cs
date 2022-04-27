using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI pointText;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject nextLevelMenu;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button nextLevelButton;

    [SerializeField] private DataManager dataManager;

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
        LevelCompleteCheck();
        GameOverCheck();
        
        pointText.text = "Point:" + point;//For debug

    }
    
    void RestartScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void NextLevel()
    {
        dataManager.IncreaseLevel();
        SceneManager.LoadScene("SampleScene");
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
}
