using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardian2: MonoBehaviour
{
    int shotcount = 0;
    GameObject player, gameManager, EnemySE;
    public GameObject bulletPrefab;
    string gamemode;
    [SerializeField] GameObject boss;
    float shottime;
    float shotspan = 0.4f;
    int HP ;
    float rollAngle = 0.0f;
    float speed = 3.0f;
    AudioSource Audio;
    [SerializeField] AudioClip SE_explode;
    [SerializeField] GameObject white_particle, black_particle;

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
        EnemySE = GameObject.Find("EnemySE");
        Audio = EnemySE.GetComponent<AudioSource>();
        gamemode = PlayerPrefs.GetString("GAMEMODE", "normal");
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
            shotcount += 1;
            if (shotcount % 2 == 0)
            {
                GameObject bullet1 = Instantiate(bulletPrefab, new Vector2(transform.position.x - 1.5f, transform.position.y), Quaternion.Euler(0.0f, 0.0f, 90));
                GameObject bullet2 = Instantiate(bulletPrefab, new Vector2(transform.position.x +1.5f, transform.position.y), Quaternion.Euler(0.0f, 0.0f, 90));
                GameObject bullet3 = Instantiate(bulletPrefab, new Vector2(transform.position.x , transform.position.y+1.5f), Quaternion.Euler(0.0f, 0.0f, 0));
                GameObject bullet4 = Instantiate(bulletPrefab, new Vector2(transform.position.x , transform.position.y-1.5f), Quaternion.Euler(0.0f, 0.0f, 0));
                bullet1.GetComponent<Guardian_Bullet_2>().angle = 180* Mathf.Deg2Rad;
                bullet2.GetComponent<Guardian_Bullet_2>().angle = 0* Mathf.Deg2Rad;
                bullet3.GetComponent<Guardian_Bullet_2>().angle = 90* Mathf.Deg2Rad;
                bullet4.GetComponent<Guardian_Bullet_2>().angle = 270 * Mathf.Deg2Rad;
            }
            else
            {
                GameObject bullet1 = Instantiate(bulletPrefab, new Vector2(transform.position.x + 0.7f, transform.position.y-0.7f), Quaternion.Euler(0.0f, 0.0f, 45));
                GameObject bullet2 = Instantiate(bulletPrefab, new Vector2(transform.position.x -0.7f, transform.position.y+0.7f), Quaternion.Euler(0.0f, 0.0f, 45));
                GameObject bullet3 = Instantiate(bulletPrefab, new Vector2(transform.position.x-0.7f, transform.position.y -0.7f), Quaternion.Euler(0.0f, 0.0f, 135));
                GameObject bullet4 = Instantiate(bulletPrefab, new Vector2(transform.position.x+0.7f, transform.position.y +0.7f), Quaternion.Euler(0.0f, 0.0f, 135));
                bullet1.GetComponent<Guardian_Bullet_2>().angle = 315* Mathf.Deg2Rad;
                bullet2.GetComponent<Guardian_Bullet_2>().angle = 135 * Mathf.Deg2Rad;
                bullet3.GetComponent<Guardian_Bullet_2>().angle = 225 * Mathf.Deg2Rad;
                bullet4.GetComponent<Guardian_Bullet_2>().angle = 45 * Mathf.Deg2Rad;
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
    void destroy()
    {
        Audio.PlayOneShot(SE_explode);
        boss.GetComponent<LastBoss>().limiter += 1;
        boss.GetComponent<BossAttack>().limiter += 1;
        Instantiate(white_particle, transform.position, transform.rotation);
        Instantiate(black_particle, transform.position, transform.rotation);
        Destroy(this.gameObject);
        gameManager.GetComponent<boss_Game>().EnergyGet(500);
    }
}
