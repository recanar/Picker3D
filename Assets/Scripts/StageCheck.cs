using System.Collections;
using UnityEngine;

public class StageCheck : MonoBehaviour
{
    GameManager gameManager;
    TextMesh textMesh;

    private int point;
    [SerializeField] private int requiredBall;
    [SerializeField] private GameObject point3DText;
    void Start()
    {
        point3DText = transform.GetChild(1).gameObject;
        textMesh = point3DText.GetComponent<TextMesh>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        BallCountText();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PointCheck());
        }
        if (other.gameObject.CompareTag("Point"))
        {
            point++;
            Destroy(other.gameObject.transform.parent.gameObject,3f);//destroy balls after 3 sec
        }
    }
    IEnumerator PointCheck()
    {
        gameManager.currentState = State.WaitingForCheck;
        yield return new WaitForSeconds(2f);
        if (point >= requiredBall)
        {
            gameManager.levelStage++;
            if (gameManager.levelStage>3)
            {
                gameManager.currentState=State.Win;
            }
            else
            gameManager.currentState=State.Playing;
            transform.GetChild(0).gameObject.SetActive(true);//activate platform for hide stage box
            point3DText.SetActive(false);
            point=0;
        }
        else
        {
            print("fail");
            gameManager.currentState = State.GameOver;
        }
    }
    private void BallCountText()
    {
        textMesh.text = point + "/" + requiredBall;
    }
}
