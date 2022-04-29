using System.Collections;
using UnityEngine;

public class StageCheck : MonoBehaviour
{
    GameManager gameManager;
    TextMesh textMesh;
    [SerializeField] private int requiredBall;
    [SerializeField] private GameObject point3DText;
    void Start()
    {
        textMesh= point3DText.GetComponent<TextMesh>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        textMesh.text = gameManager.point + "/" + requiredBall;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PointCheck());
        }
        if (other.gameObject.CompareTag("Point"))
        {
            gameManager.point++;
            Destroy(other.gameObject.transform.parent.gameObject,3f);//destroy balls after 3 sec
        }
    }
    IEnumerator PointCheck()
    {
        gameManager.currentState = State.WaitingForCheck;
        yield return new WaitForSeconds(2f);
        if (gameManager.point >= requiredBall)
        {
            gameManager.levelStage++;
            if (gameManager.levelStage>3)
            {
                gameManager.currentState=State.Win;
            }
            else
            gameManager.currentState=State.Playing;
            transform.parent.GetChild(0).gameObject.SetActive(true);//activate platform for hide stage box
            point3DText.SetActive(false);
            gameManager.point=0;
        }
        else
        {
            print("fail");
            gameManager.currentState = State.GameOver;
        }
    }
}
