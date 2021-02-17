using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet3_boss: MonoBehaviour
{

    public GameObject bulletPrefab;
   public float angle;
    float speed=6.0f;
    float deletetime,generatetime;
    float deletespan = 3.5f, generatespan=0.4f;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        SetVelocity(angle, speed);
    }

    // Update is called once per frame
    void Update()
    {
        generatetime += Time.deltaTime;
        deletetime += Time.deltaTime;
        if (deletetime > deletespan)
        {
            Destroy(this.gameObject);
        }

        Vector2 next = player.transform.position;
        Vector2 now = transform.position;
        // 目的となる角度を取得する
        Vector2 d = next - now;
        float targetAngle = Mathf.Atan2(d.y, d.x) * Mathf.Rad2Deg;

        if (generatetime > generatespan)
        {
            GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, targetAngle - 90)));
            bullet.GetComponent<bullet_enemy3>().angle = targetAngle * Mathf.Deg2Rad;
            generatetime = 0;
        }

    }

    void SetVelocity(float direction, float speed)
    {
        float vx = Mathf.Cos(direction) * speed;
        float vy = Mathf.Sin(direction) * speed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(vx, vy);
    }
}
