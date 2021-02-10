using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading.Tasks;

public class Enemy8 :EnemyBase
{
    private float range;

    [SerializeField] GameObject red_particle,white_particle;
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
            GenerateBullet();
        }
    }

    protected override void GenerateBullet()
    {
        range = Random.Range(-20.0f, 20.0f);
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, targetangle - 90)));
        bullet.GetComponent<bullet8_enemy>().angle = (targetangle + range) * Mathf.Deg2Rad;
        shottime = 0;
    }
    protected override void Destroy()
    {
        Audio.PlayOneShot(SE_explode);
        Instantiate(white_particle, transform.position, transform.rotation);
        Instantiate(red_particle, transform.position, transform.rotation);
        gameManager.GetComponent<GameManager>().EnergyGet(getscore);
        Destroy(this.gameObject);
    }

}
