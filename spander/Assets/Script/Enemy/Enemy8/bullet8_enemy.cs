using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet8_enemy : MonoBehaviour
{
    GameObject player;
    public float angle;
    float speed = 6.5f;
    float deletetime;
    float deletespan = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
        SetVelocity(angle, speed);

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
