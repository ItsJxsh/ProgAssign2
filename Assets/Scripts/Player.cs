using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public float speed = 4.0f;
    public int keys;
    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Challenge: Rotate the player with E and Q, then move the player in that direction!
    void Update()
    {
        float dt = Time.deltaTime;
        float xDir = 0.0f;
        float yDir = 0.0f;


        if (Input.GetKey(KeyCode.W))
        {
            gameObject.GetComponent<AnimationScript>().idle = false;
            yDir = 1.0f;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            gameObject.GetComponent<AnimationScript>().idle = false;
            yDir = -1.0f;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            gameObject.GetComponent<AnimationScript>().idle = false;
            xDir = -1.0f;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<AnimationScript>().idle = false;
            xDir = 1.0f;
        }
        else
        {
            gameObject.GetComponent<AnimationScript>().idle = true;
        }


        Vector2 direction = new Vector2(xDir, yDir).normalized;
        rb.velocity = direction * speed;
    }

}