using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOffSet : MonoBehaviour
{
    Vector3 offset;
    GameObject player;
    void Awake()
    {
        offset = transform.position;
        player = GameObject.Find("Player");
    }
    private void OnEnable()
    {
        transform.rotation= Quaternion.identity;
        transform.Rotate(Vector3.right*30);
    }
    void LateUpdate()
    {
        transform.position = offset + player.transform.position;
    }
}
