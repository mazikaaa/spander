using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    //リミッター解除前
    public int limiter;
    int randomangle;
    float shotcount1;
    float shotspan1 = 1.0f;
    [SerializeField] GameObject bulletPrefab1;

    //リミッター解除後
    int i,color;
    float[] shotcount2 = new float[4];
    float[] shotspan2 = { 0.33f, 3.0f, 5.0f,7.0f};
    [SerializeField] GameObject[] bulletPrefab2 = new GameObject[3];
    [SerializeField] GameObject[] bulletPrefab3 = new GameObject[7];
    public float shotspeed,deletetime; 


    // Start is called before the first frame update
    void Start()
    {
        limiter=0;
        shotcount2[3] = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (limiter < 3)
        {
            shotcount1 += Time.deltaTime;
            if (shotcount1>shotspan1) {
                randomangle = Random.Range(-45, 46);
                GameObject bullet1 = Instantiate(bulletPrefab1, new Vector3(transform.position.x - 3.0f, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 90 + randomangle)));
                bullet1.GetComponent<Boss_Bullet1>().angle = (180 + randomangle) * Mathf.Deg2Rad;
                GameObject bullet2 = Instantiate(bulletPrefab1, new Vector3(transform.position.x + 3.0f, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 270 + randomangle)));
                bullet2.GetComponent<Boss_Bullet1>().angle = (0 + randomangle) * Mathf.Deg2Rad;
                GameObject bullet3 = Instantiate(bulletPrefab1, new Vector3(transform.position.x, transform.position.y+3.0f, 0), Quaternion.Euler(new Vector3(0, 0, 0 + randomangle)));
                bullet3.GetComponent<Boss_Bullet1>().angle = (90 + randomangle) * Mathf.Deg2Rad;
                GameObject bullet4 = Instantiate(bulletPrefab1, new Vector3(transform.position.x , transform.position.y-3.0f, 0), Quaternion.Euler(new Vector3(0, 0, 180 + randomangle)));
                bullet4.GetComponent<Boss_Bullet1>().angle = (270 + randomangle) * Mathf.Deg2Rad;
                shotcount1 = 0.0f;
            }
        }
        else
        {
            for (i = 0; i < 4; i++)
            {
                shotcount2[i] += Time.deltaTime;
            }
            //ボスの攻撃1
            if (shotcount2[0] > shotspan2[0])
            {
                randomangle = Random.Range(-45, 46);
                GameObject bullet1 = Instantiate(bulletPrefab2[0], new Vector3(transform.position.x - 3.0f, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 90 + randomangle)));
                bullet1.GetComponent<Boss_Bullet1>().angle = (180 + randomangle) * Mathf.Deg2Rad;
                GameObject bullet2 = Instantiate(bulletPrefab2[0], new Vector3(transform.position.x + 3.0f, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 270 + randomangle)));
                bullet2.GetComponent<Boss_Bullet1>().angle = (0 + randomangle) * Mathf.Deg2Rad;
                GameObject bullet3 = Instantiate(bulletPrefab2[0], new Vector3(transform.position.x, transform.position.y + 3.0f, 0), Quaternion.Euler(new Vector3(0, 0, 0 + randomangle)));
                bullet3.GetComponent<Boss_Bullet1>().angle = (90 + randomangle) * Mathf.Deg2Rad;
                GameObject bullet4 = Instantiate(bulletPrefab2[0], new Vector3(transform.position.x, transform.position.y - 3.0f, 0), Quaternion.Euler(new Vector3(0, 0, 180 + randomangle)));
                bullet4.GetComponent<Boss_Bullet1>().angle = (270 + randomangle) * Mathf.Deg2Rad;
                shotcount2[0] = 0.0f;
            }

            //ボスの攻撃2
            if (shotcount2[1] > shotspan2[1])
            {
                GameObject bullet1 = Instantiate(bulletPrefab2[1], new Vector3(transform.position.x + 2.0f, transform.position.y-2.0f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
                bullet1.GetComponent<Boss_Bullet2>().angle =315 * Mathf.Deg2Rad;
                GameObject bullet2 = Instantiate(bulletPrefab2[1], new Vector3(transform.position.x -2.0f, transform.position.y-2.0f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
                bullet2.GetComponent<Boss_Bullet2>().angle = 225 * Mathf.Deg2Rad;
                GameObject bullet3 = Instantiate(bulletPrefab2[1], new Vector3(transform.position.x-2.0f, transform.position.y + 2.0f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
                bullet3.GetComponent<Boss_Bullet2>().angle = 135 * Mathf.Deg2Rad;
                GameObject bullet4 = Instantiate(bulletPrefab2[1], new Vector3(transform.position.x+2.0f, transform.position.y + 2.0f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
                bullet4.GetComponent<Boss_Bullet2>().angle = 45 * Mathf.Deg2Rad;
                shotcount2[1] = 0.0f;
            }

            //ボスの攻撃3
            if (shotcount2[2] > shotspan2[2])
            {
                for (i = 0; i < 36; i++)
                {
                    color = Random.Range(0, 7);
                    shotspeed = Random.Range(6.0f, 10f);
                    deletetime = Random.Range(6.0f, 10.0f);
                    GameObject bullet = Instantiate(bulletPrefab3[color], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
                    Guardian_Bullet_1 bulletdata = bullet.GetComponent<Guardian_Bullet_1>();
                    bulletdata.angle = i*10*Mathf.Deg2Rad;
                    bulletdata.speed = shotspeed;
                    bulletdata.deletespan = deletetime;
                }
                shotcount2[2] = 0.0f;
            }

            if (shotcount2[3] > shotspan2[3])
            {
                GameObject bullet1 = Instantiate(bulletPrefab2[2], new Vector3(transform.position.x + 1.5f, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
                GameObject bullet2 = Instantiate(bulletPrefab2[2], new Vector3(transform.position.x - 1.5f, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
                bullet1.GetComponent<BulletGenerator>().angle = 0f;
                bullet2.GetComponent<BulletGenerator>().angle = 0f;
                shotcount2[3] = 0.0f;
            }

        }
    }
}
