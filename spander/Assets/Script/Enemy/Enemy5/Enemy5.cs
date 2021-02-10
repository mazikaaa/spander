using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading.Tasks;

public class Enemy5 : EnemyBase
{
  
    [SerializeField] GameObject blue_particle, white_particle;
 
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
        //速度決定
        SetVelocity();

        if (shottime > shotspan)
        {
            GenerateBullet();
        }
    }

    protected override void Destroy()
    {
        Audio.PlayOneShot(SE_explode);
        Instantiate(blue_particle, transform.position, transform.rotation);
        Instantiate(white_particle, transform.position, transform.rotation);
        gameManager.GetComponent<GameManager>().EnergyGet(getscore);
        Destroy(this.gameObject);
    }

    protected override void GenerateBullet()
    {
        float random = Random.Range(-45.0f, 45.0f);
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, targetangle + (90.0f + random))));
        bullet.GetComponent<BulletBase>().angle = (targetangle + random) * Mathf.Deg2Rad;
        shottime = 0;
    }


}
