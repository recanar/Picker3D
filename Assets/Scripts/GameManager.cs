using UnityEngine;

public enum State
{
    WaitingTap,
    Playing,
    WaitingForCheck,//checking ball count on enter trigger for stage
    GameOver,
    Win
}
public class GameManager : MonoBehaviour
{
    [HideInInspector] public State currentState;

    public int numberOfStagesOnThisLevel=3;
    [HideInInspector] public int levelStage = 1;

    PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        StateChangeWaitToPlaying(); ;//starts game with horizontal input
        CheckLevelComplete();
    }
    private void StateChangeWaitToPlaying()
    {
        if (currentState==State.WaitingTap)
        {
            if (playerController.HorizontalInput > 0.2 || playerController.HorizontalInput < -0.2)
            {
                currentState = State.Playing;
                numberOfStagesOnThisLevel = GameObject.FindGameObjectsWithTag("Stage").Length;
            }
        }
    }
    private void CheckLevelComplete()
    {
        if (levelStage>numberOfStagesOnThisLevel)
        {
            currentState = State.Win;
        }
    }
}
