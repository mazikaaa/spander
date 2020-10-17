using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading.Tasks;

public class Enemy4 : MonoBehaviour
{
    int shotcount=0;
    GameObject player, gameManager;
    public GameObject bulletPrefab;
    float shottime;
    float shotspan = 0.4f;
    int HP = 120;
    float rollAngle = 0.0f;
    float speed = 2.0f;
    AudioSource Audio;
    [SerializeField] AudioClip SE_explode;
    [SerializeField] GameObject red_particle,yellow_particle;

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
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        shottime += Time.deltaTime;

        // プレイヤーと炎の座標所得
        Vector2 next = player.transform.position;
        Vector2 now = transform.position;
        // 目的となる角度を取得する
        Vector2 d = next - now;
        float targetAngle = Mathf.Atan2(d.y, d.x) * Mathf.Rad2Deg;


        // 画像を回転
        rollAngle += 3.0f;
        var renderer = GetComponent<SpriteRenderer>();
        renderer.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, rollAngle));

        // 新しい速度を設定する
        SetVelocity(targetAngle, speed);

        if (shottime > shotspan)
        {
            shotcount += 1;
            if (shotcount % 2 == 0)
            {
                GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, rollAngle)));
                bullet.GetComponent<bullet_enemy4>().angle = rollAngle * Mathf.Deg2Rad;
            }
            else
            {
                GameObject bullet2 = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, rollAngle - 180.0f)));
                bullet2.GetComponent<bullet_enemy4>().angle = rollAngle * Mathf.Deg2Rad;
            }
            shottime = 0;
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
    public void destroy()
    {
        Instantiate(yellow_particle, transform.position, transform.rotation);
        Instantiate(red_particle, transform.position, transform.rotation);
        Destroy(this.gameObject);
        gameManager.GetComponent<GameManager>().EnergyGet(50);
    }
}
