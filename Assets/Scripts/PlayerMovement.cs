using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed;
    Rigidbody rb;
    GameManager manager;
    float horizontal;
    float limitMove = 3f;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        speed = 7;
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //Test();//for debugging
        horizontal = Input.GetAxis("Horizontal") * speed;//left-right movement input
        
        if (manager.isPlaying)
        {
            if (transform.position.x<-limitMove||transform.position.x>limitMove)
            {
                rb.velocity= new Vector3(0, 0, speed);
            }//if player reaches any side of limit, stop velocity for horizontal
            if (transform.position.x > limitMove && horizontal<0)
            {
                rb.velocity = new Vector3(horizontal, 0, speed);
            }//if player reach limit for right side only moves left
            if (transform.position.x < -limitMove && horizontal > 0)
            {
                rb.velocity = new Vector3(horizontal, 0, speed);
            }//if player reach limit for left side only moves right
            if (transform.position.x <= limitMove && transform.position.x >= -limitMove)
            {
                rb.velocity = new Vector3(horizontal, 0, speed);
            }//if stays middle can go any side
        }//move player
        else
        {
            rb.velocity = Vector3.zero;
        }//stop player
    }

    private void Test()//for debugging
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!manager.isPlaying)
            {
                manager.isPlaying = true;
            }
            else
                manager.isPlaying = false;
        }//start/stop player move
    }
}
