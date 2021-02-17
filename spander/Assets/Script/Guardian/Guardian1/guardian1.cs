using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardian1: MonoBehaviour
{
    int color, shotangle;
    float shotspeed,shotdelete;
    int shotcount = 0;
    string gamemode;
    GameObject player, gameManager,EnemySE;
    AudioSource Audio;
    [SerializeField] GameObject[] bulletPrefab=new GameObject[7];
    [SerializeField] GameObject boss;
    float shottime;
    float shotspan = 0.1f;
    int HP;
    float rollAngle = 0.0f;
    float speed = 4.0f;
    [SerializeField] AudioClip SE_explode;
    [SerializeField] GameObject yellow_particle,purple_particle;

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

        Vector2 next = player.transform.position;
        Vector2 now = transform.position;
        // 目的となる角度を取得する
        Vector2 d = next - now;
        float targetAngle = Mathf.Atan2(d.y, d.x) * Mathf.Rad2Deg;

        SetVelocity(targetAngle, speed);

        if (shottime > shotspan)
        {
            color= Random.Range(0, 6);
            shotangle = Random.Range(0, 359);
            shotspeed = Random.Range(5.0f, 9.0f);
            shotdelete = Random.Range(5.0f, 9.0f);
            GameObject bullet = Instantiate(bulletPrefab[color], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            Guardian_Bullet_1 bulletdata = bullet.GetComponent<Guardian_Bullet_1>();
            bulletdata.angle = shotangle * Mathf.Deg2Rad;
            bulletdata.speed = shotspeed;
            bulletdata.deletespan = shotdelete;
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
        boss.GetComponent<LastBoss>().limiter+=1;
        boss.GetComponent<BossAttack>().limiter += 1;
        Instantiate(yellow_particle, transform.position, transform.rotation);
        Instantiate(purple_particle, transform.position, transform.rotation);
        Destroy(this.gameObject);
        gameManager.GetComponent<boss_Game>().EnergyGet(500);
    }
}
