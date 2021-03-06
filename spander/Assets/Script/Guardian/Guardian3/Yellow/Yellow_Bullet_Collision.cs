﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow_Bullet_Collision : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerManager>().Damage(15);
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "barrier.player")
        {
            Destroy(this.gameObject);
        }
    }

}
