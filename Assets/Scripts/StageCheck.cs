using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCheck : MonoBehaviour
{
    GameManager manager;
    TextMesh textMesh;
    [SerializeField] private int requiredBall;
    [SerializeField] private GameObject point3DText;
    void Start()
    {
        textMesh= point3DText.GetComponent<TextMesh>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        textMesh.text = manager.point + "/" + requiredBall;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            manager.isPlaying = false;
            StartCoroutine(PointCheck());
        }
        if (other.gameObject.CompareTag("Point"))
        {
            manager.point++;
        }
    }
    IEnumerator PointCheck()
    {
        yield return new WaitForSeconds(2f);
        if (manager.point >= requiredBall)
        {
            manager.levelStage++;
            if (manager.levelStage>3)
            {
                print("Level Complete");
            }
            else
            manager.isPlaying=true;
            transform.parent.GetChild(0).gameObject.SetActive(true);
            point3DText.SetActive(false);
            manager.point=0;
        }
        else
        {
            print("fail");
            manager.isGameOver = true;
        }
    }
}
