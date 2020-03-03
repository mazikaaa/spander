﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet5_enemy : MonoBehaviour
{
    GameObject player;
    public float Angle;
    float speed = 7.0f;
    float deletetime;
    float deletespan = 7.0f;
    // Start is called before the first frame update
    void Start()
    {
        
        SetVelocity(Angle, speed);

    }

    // Update is called once per frame
    void Update()
    {
        deletetime += Time.deltaTime;
        if (deletetime > deletespan)
        {
            Destroy(this.gameObject);
        }

    }

    void SetVelocity(float direction, float speed)
    {
        float vx = Mathf.Cos(direction) * speed;
        float vy = Mathf.Sin(direction) * speed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(vx, vy);
    }
}
