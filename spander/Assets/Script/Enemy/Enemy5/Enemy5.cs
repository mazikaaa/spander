using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading.Tasks;

public class Enemy5 : MonoBehaviour
{
    int shotcount = 0;
    GameObject player, gameManager;
    public GameObject bulletPrefab;
    float shottime;
    float shotspan = 0.7f;
    int HP = 150;
    float speed = 2.5f;
    AudioSource Audio;
    [SerializeField] AudioClip SE_explode;
    [SerializeField] GameObject blue_particle, white_particle;
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
    }

    // Update is called once per frame
    void Update()
    {
        shottime += Time.deltaTime;

        // プレイヤーと敵の座標所得
        Vector2 next = player.transform.position;
        Vector2 now = transform.position;
        // 目的となる角度を取得する
        Vector2 d = next - now;
        float targetAngle = Mathf.Atan2(d.y, d.x) * Mathf.Rad2Deg;

        //速度決定
        SetVelocity(targetAngle, speed);

        // 画像の角度を移動方向に向ける
        var renderer = GetComponent<SpriteRenderer>();
        renderer.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, targetAngle - 90));
        if (shottime > shotspan)
        {
            float random = Random.Range(-45.0f, 45.0f);
            GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, targetAngle +(90.0f+random))));
            bullet.GetComponent<bullet5_enemy>().Angle = (targetAngle+random) * Mathf.Deg2Rad;
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
    void destroy()
    {
        Instantiate(blue_particle, transform.position, transform.rotation);
        Instantiate(white_particle, transform.position, transform.rotation);
        Destroy(this.gameObject);
        gameManager.GetComponent<GameManager>().EnergyGet(70);
    }
}
