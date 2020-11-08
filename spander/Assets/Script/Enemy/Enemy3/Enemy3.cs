using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading.Tasks;

public class Enemy3 : MonoBehaviour
{
    GameObject player,gameManager, EnemySE;
    public GameObject bulletPrefab;
    float shottime;
    float shotspan=1.0f;
    int HP=120;
    float speed = 4.0f;
    AudioSource Audio;
    [SerializeField] GameObject Ene3_particle;
    [SerializeField] AudioClip SE_explode;

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
        EnemySE = GameObject.Find("EnemySE");
        Audio = EnemySE.GetComponent<AudioSource>();
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
        
        // 画像の角度を移動方向に向ける
        var renderer = GetComponent<SpriteRenderer>();
        renderer.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, targetAngle - 90));


        // 新しい速度を設定する
        SetVelocity(targetAngle, speed);

        if (shottime > shotspan)
        {
            GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, targetAngle - 90)));
            bullet.GetComponent<bullet_enemy3>().angle = targetAngle * Mathf.Deg2Rad;
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
   public  void destroy()
    {
        Audio.PlayOneShot(SE_explode);
        Instantiate(Ene3_particle, transform.position, transform.rotation);
        gameManager.GetComponent<GameManager>().EnergyGet(60);
        Destroy(this.gameObject);
    }

}
