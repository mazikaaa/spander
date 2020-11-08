using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian3 : MonoBehaviour
{
    int shot;
    int shotcount = 0;
    string gamemode;
    GameObject player, gameManager, EnemySE;
    AudioSource Audio;
    [SerializeField] GameObject[] bulletPrefab=new GameObject[4];
    [SerializeField] GameObject boss;
    float shottime;
    float shotspan = 1.0f;
    int HP;
    float rollAngle = 0.0f;
    float speed = 2.5f;
    [SerializeField] GameObject red_particle, blue_particle;
    [SerializeField] AudioClip SE_explode;

    // Start is called before the first frame update

    void SetVelocity(float direction, float speed)
    {
        float vx = Mathf.Cos(Mathf.Deg2Rad * direction) * speed;
        float vy = Mathf.Sin(Mathf.Deg2Rad * direction) * speed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(vx, vy);
    }
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
        gamemode = PlayerPrefs.GetString("GAMEMODE", "normal");
        EnemySE = GameObject.Find("EnemySE");
        Audio = EnemySE.GetComponent<AudioSource>();
        HP = 800;
        if (gamemode == "hard")
        {
            HP = 1000;
        }
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

        SetVelocity(targetAngle, speed);

        if (shottime > shotspan)
        {
            shot = Random.Range(0, 4);
            GameObject bullet = Instantiate(bulletPrefab[shot], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            bullet.GetComponent<Guardian_Bullet_3>().angle = (shot * 90 + 45) * Mathf.Deg2Rad;
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
        Audio.PlayOneShot(SE_explode);
        boss.GetComponent<LastBoss>().limiter += 1;
        boss.GetComponent<BossAttack>().limiter += 1;
        Instantiate(red_particle, transform.position, transform.rotation);
        Instantiate(blue_particle, transform.position, transform.rotation);
        Destroy(this.gameObject);
        gameManager.GetComponent<boss_Game>().EnergyGet(500);
    }
}
