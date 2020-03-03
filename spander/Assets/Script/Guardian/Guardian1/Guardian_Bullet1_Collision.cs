using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian_Bullet1_Collision : MonoBehaviour
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
            Destroy(this.gameObject);
            player.GetComponent<PlayerManager>().Damage(15);
        }

        if (col.gameObject.tag == "barrier.player")
        {
            Destroy(this.gameObject);
        }
    }
}
