using System.Collections;
using UnityEngine;
public class StageCheck : MonoBehaviour
//Script for stage prefab
{
    GameManager gameManager;
    TextMesh textMesh;

    private int point;
    public int RequiredBall { get; set; }

    private GameObject point3DText;
    private GameObject hiddenPlatform;
    void Start()
    {
        hiddenPlatform = transform.GetChild(0).gameObject;
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
            Destroy(other.gameObject,3f);//destroy balls after 3 sec
        }
        if (other.gameObject.CompareTag("RedPoint"))
        {
            point--;
            Destroy(other.gameObject, 3f);//destroy balls after 3 sec
        }
    }
    IEnumerator PointCheck()
    {
        gameManager.currentState = State.WaitingForCheck;
        yield return new WaitForSeconds(2f);
        if (point >= RequiredBall)
        {
            gameManager.levelStage++;
            if (gameManager.levelStage>3)
            {
                gameManager.currentState=State.Win;
            }
            else
            gameManager.currentState=State.Playing;
            hiddenPlatform.SetActive(true);//activate platform for hide stage box
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
        textMesh.text = point + "/" + RequiredBall;
    }
}
