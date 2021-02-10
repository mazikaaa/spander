using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading.Tasks;

public class Enemy4 : EnemyBase
{
    private int shotcount;
    private float rollAngle=0.0f;
    [SerializeField] GameObject red_particle,yellow_particle;


    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        shottime += Time.deltaTime;

        SetAngle();
        SetVelocity();

        if (shottime > shotspan)
        {
            shotcount += 1;
            if (shotcount % 2 == 0)
            {
                GenerateBullet(rollAngle);
            }
            else
            {
                GenerateBullet(rollAngle - 180.0f);
            }
            shottime = 0;
        }
    }

    protected override void SetAngle()
    {

        Vector2 next = player.transform.position;
        Vector2 now = transform.position;
        // 目的となる角度を取得する
        Vector2 d = next - now;
        targetangle = Mathf.Atan2(d.y, d.x) * Mathf.Rad2Deg;

        rollAngle += 3.0f;
        GetComponent<Renderer>().transform.localRotation = Quaternion.Euler(new Vector3(0, 0, rollAngle));
    }

     void GenerateBullet(float angle)
    {
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, angle)));
        bullet.GetComponent<BulletBase>().angle = angle * Mathf.Deg2Rad;
    }

    protected override void Destroy()
    {
        Audio.PlayOneShot(SE_explode);
        Instantiate(red_particle, transform.position, transform.rotation);
        Instantiate(yellow_particle, transform.position, transform.rotation);
        gameManager.GetComponent<GameManager>().EnergyGet(getscore);
        Destroy(this.gameObject);
    }

}
