using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI pointText;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private Button restartButton;


    [HideInInspector] public bool isPlaying;
    [HideInInspector] public bool isGameOver;

    [HideInInspector] public int point = 0;
    [HideInInspector] public int levelStage = 1;
    [HideInInspector] public int currentLevel = 1;


    void Update()
    {
        if (levelStage <= 3)
            levelText.text = "Level:" + currentLevel + "-" + levelStage;
        else
            levelText.text = "Finished";
        pointText.text = "Point:" + point;

        if (isGameOver)
        {
            gameOverMenu.SetActive(true);
        }
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
}
