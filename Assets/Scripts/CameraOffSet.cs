using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOffSet : MonoBehaviour
{
    Vector3 offset;
    GameObject player;
    void Start()
    {
        offset = transform.position;
        player = GameObject.Find("Player");
    }
    void LateUpdate()
    {
        transform.position = offset + player.transform.position;
    }
}
