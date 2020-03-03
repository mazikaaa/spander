using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading.Tasks;

public class boss : MonoBehaviour
{
    GameObject player,gameManager;
    GameObject[] bullet2 = new GameObject[16];
    GameObject[] bullet3 = new GameObject[4];
    public GameObject bulletPrefab1,bulletPrefab2,bulletPrefab3;
    float shottime1, shottime2, shottime3,randomangle;
    float shotspan1=0.2f;
    float shotspan2 = 3.0f;
    float shotspan3 = 7.0f;
    int i, HP=350;
    AudioSource Audio;
    [SerializeField] AudioClip SE_explode;
    [SerializeField] GameObject red_particle, white_particle,blue_particle;

    float speed = 4.0f;
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
        shottime1 += Time.deltaTime;
        shottime2 += Time.deltaTime;
        shottime3 += Time.deltaTime;
        // プレイヤーと炎の座標所得
        Vector2 next = player.transform.position;
        Vector2 now = transform.position;
        // 目的となる角度を取得する
        Vector2 d = next - now;
        float targetAngle = Mathf.Atan2(d.y, d.x) * Mathf.Rad2Deg;
        
        // 画像の角度を移動方向に向ける
        var renderer = GetComponent<SpriteRenderer>();
        renderer.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, targetAngle - 90));


        // 新しい速度を設定する
        SetVelocity(targetAngle, speed);

        if (shottime1 > shotspan1)
        {
            randomangle = Random.Range(0, 360.0f);
            GameObject bullet1 = Instantiate(bulletPrefab1, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, randomangle-90)));
            bullet1.GetComponent<bullet1_boss>().angle = randomangle;
            shottime1 = 0;
        }

        if (shottime2 > shotspan2)
        {
            for (i = 0; i <16; i++)
            { 
            bullet2[i] = Instantiate(bulletPrefab2, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            bullet2[i].GetComponent<bullet2_boss>().angle = i * 22.5f;
            }
            shottime2= 0;
        }


        if (shottime3 > shotspan3)
        {
            for (i = 0; i < 4; i++)
            {
                bullet3[i] = Instantiate(bulletPrefab3, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
                bullet3[i].GetComponent<bullet3_boss>().angle = targetAngle-90.0f*i;
            }
            shottime3 = 0;
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
        Instantiate(white_particle, transform.position, transform.rotation);
        Instantiate(red_particle, transform.position, transform.rotation);
        Instantiate(blue_particle, transform.position, transform.rotation);
        Destroy(this.gameObject);
        gameManager.GetComponent<GameManager>().EnergyGet(300);
    }
}
