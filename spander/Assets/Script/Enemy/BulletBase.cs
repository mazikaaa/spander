using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    public float angle,speed;
    public int attack;
    protected float deletetime;
    public float deletespan = 5.0f;
    GameObject player;
    [SerializeField]Rigidbody2D rigid2D;

    // Start is called before the first frame update
    protected void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        SetVelocity();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    protected void SetVelocity()
    {
        float vx = Mathf.Cos(angle) * speed;
        float vy = Mathf.Sin(angle) * speed;
        rigid2D .velocity = new Vector2(vx, vy);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerManager>().Damage(attack);
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "barrier.player")
        {
            Destroy(this.gameObject);
        }
    }


}
