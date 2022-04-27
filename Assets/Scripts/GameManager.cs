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

    [HideInInspector] public bool isPlaying;
    [HideInInspector] public bool isGameOver;

    [HideInInspector] public int point = 0;
    [HideInInspector] public int levelStage = 1;
    [HideInInspector] public int currentLevel = 1;


    void Update()
    {
        LevelCompleteCheck();
        GameOverCheck();
        
        pointText.text = "Point:" + point;//For debug

    }
    void Start()
    {
        Button resBtn = restartButton.GetComponent<Button>();
        resBtn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void LevelCompleteCheck()
    {
        if (levelStage <= 3)
        {
            levelText.text = "Level:" + currentLevel + "-" + levelStage;
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
