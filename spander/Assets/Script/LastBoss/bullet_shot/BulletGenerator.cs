using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public float angle,newangle;
    GameObject player;
    public GameObject bulletPrefab;
    float shottime,deletetime;
    float shotspan = 0.5f;
    float deletespan = 5.0f;
    int HP = 200;
    AudioSource Audio;
    [SerializeField] AudioClip SE_explode;
    [SerializeField] Rigidbody2D rigidbody2D;
    float speed = 6.0f;

    float Direction
    {
        get { return Mathf.Atan2(rigidbody2D.velocity.y, rigidbody2D.velocity.x) * Mathf.Rad2Deg; }
    }

    /// 角度と速度から移動速度を設定する
    void SetVelocity(float direction, float speed)
    {
        float vx = Mathf.Cos(Mathf.Deg2Rad * direction) * speed;
        float vy = Mathf.Sin(Mathf.Deg2Rad * direction) * speed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(vx, vy);
    }
    // Start is called before the first frame update
    void Start()
    {
        SetVelocity(angle, speed);
        player = GameObject.Find("Player");
        newangle = angle;
    }

    // Update is called once per frame
    void Update()
    {
        shottime += Time.deltaTime;
        deletetime += Time.deltaTime;

        // プレイヤーと炎の座標所得
        Vector2 next = player.transform.position;
        Vector2 now = transform.position;
        // 目的となる角度を取得する
        Vector2 d = next - now;
        float targetAngle = Mathf.Atan2(d.y, d.x) * Mathf.Rad2Deg;

        newangle = Direction;
        float deltaangle = Mathf.DeltaAngle(newangle, targetAngle);

        if (Mathf.Abs(deltaangle) < 10.0f)
        {
            ;
        }
        else if (deltaangle > 0)
        {
            newangle += 10.0f;
        }
        else
        {
            newangle -= 10.0f;
        }

        SetVelocity(newangle, speed);

        if (shottime > shotspan)
        {
            GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0,newangle-angle-90)));
            bullet.GetComponent<GenerateBullet>().angle = newangle * Mathf.Deg2Rad;
            shottime = 0;
        }

        if (deletetime > deletespan)
        {
            Destroy(this.gameObject);
        }
    }

    public void Damage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            destroy();
        }
    }

    void destroy()
    {
        Destroy(this.gameObject);
    }

}
