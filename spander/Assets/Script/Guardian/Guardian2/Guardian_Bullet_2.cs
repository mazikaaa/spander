using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian_Bullet_2: MonoBehaviour
{
    public float angle;
    float speed = 8.0f;
    float deletetime;
    float deletespan = 6.0f;
    void SetVelocity(float direction, float speed)
    {
        float vx = Mathf.Cos(direction) * speed;
        float vy = Mathf.Sin(direction) * speed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(vx, vy);
    }

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

}
