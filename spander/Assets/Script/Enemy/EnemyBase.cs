using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    protected GameObject player, gameManager, EnemySE;

    public GameObject bulletPrefab;
    [SerializeField] GameObject Ene_particle;
    public EnemyBase enemybase;

    protected float shottime;
    protected float targetangle;
    [SerializeField]float speed ;
    public int getscore,attack;
    public float shotspan;
    public int HP;

    protected AudioSource Audio;
    protected Rigidbody2D rigid;
    protected SpriteRenderer renderer;

    public AudioClip SE_explode;


    protected void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
        EnemySE = GameObject.Find("EnemySE");
        Audio = EnemySE.GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void SetVelocity()
    {
        float vx = Mathf.Cos(Mathf.Deg2Rad * targetangle) * speed;
        float vy = Mathf.Sin(Mathf.Deg2Rad * targetangle) * speed;
        rigid.velocity = new Vector2(vx, vy);
    }

    protected virtual void SetAngle()
    {
        Vector2 next = player.transform.position;
        Vector2 now = transform.position;
        // 目的となる角度を取得する
        Vector2 d = next - now;
        targetangle = Mathf.Atan2(d.y, d.x) * Mathf.Rad2Deg;
        renderer.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, targetangle - 90));
    }

    protected virtual void GenerateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, targetangle - 90)));
        bullet.GetComponent<BulletBase>().angle = targetangle * Mathf.Deg2Rad;
        shottime = 0;
    }

    public void Damage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Destroy();
        }
    }

    protected virtual void Destroy()
    {
        Audio.PlayOneShot(SE_explode);
        Instantiate(Ene_particle, transform.position, transform.rotation);
        gameManager.GetComponent<GameManager>().EnergyGet(getscore);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "bullet.player")
        {
            Damage(col.gameObject.GetComponent<bulletManager>().power);
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "wave.player")
        {
            Damage(col.gameObject.GetComponent<waveManager>().power);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerManager>().Damage(attack);
            Destroy();
        }
    }

}
