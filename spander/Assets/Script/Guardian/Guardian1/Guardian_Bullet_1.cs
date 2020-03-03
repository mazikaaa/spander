using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian_Bullet_1: MonoBehaviour
{
    public float angle;
    public float speed;
    float deletetime;
    public float deletespan;
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
