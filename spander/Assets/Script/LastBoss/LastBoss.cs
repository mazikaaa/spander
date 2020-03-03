using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBoss : MonoBehaviour
{
    Rigidbody2D boss;
    public int limiter;
    string gamemode;
    float speed=3.0f;
    GameObject player,gameManager;
    public int HP;
    [SerializeField] GameObject gray_particle, black_particle,blue_particle;
    [SerializeField] GameObject barrier;

    void SetVelocity(float direction, float speed)
    {
        float vx = Mathf.Cos(Mathf.Deg2Rad * direction) * speed;
        float vy = Mathf.Sin(Mathf.Deg2Rad * direction) * speed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(vx, vy);
    }
    // Start is called before the first frame update
    void Start()
    {
        limiter = 0;
        boss = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
        gamemode = PlayerPrefs.GetString("GAMEMODE", "normal");
        HP = 2000;
        if (gamemode == "hard")
        {
            HP = 2500;
        }

    }

    // Update is called once per frame
    void Update()
    {
        

        if (limiter >= 3)
        {
            if (barrier.activeSelf)
            {
                barrier.SetActive(false);
            }
            // プレイヤーと炎の座標所得
            Vector2 next = player.transform.position;
            Vector2 now = transform.position;
            // 目的となる角度を取得する
            Vector2 d = next - now;
            float targetAngle = Mathf.Atan2(d.y, d.x) * Mathf.Rad2Deg;

            SetVelocity(targetAngle, speed);
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
        Instantiate(gray_particle, transform.position, transform.rotation);
        Instantiate(black_particle, transform.position, transform.rotation);
        Instantiate(blue_particle, transform.position, transform.rotation);
        Destroy(this.gameObject);
        gameManager.GetComponent<boss_Game>().GameClear();
    }
}
