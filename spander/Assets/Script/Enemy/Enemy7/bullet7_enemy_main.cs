using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet7_enemy_main : BulletBase
{
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        speed -= 0.1f;
        if (speed < 0.5f)
        {
            GameObject bullet1 = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            GameObject bullet2 = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            GameObject bullet3 = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            GameObject bullet4 = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            GameObject bullet5 = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            GameObject bullet6 = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            GameObject bullet7 = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            GameObject bullet8 = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            bullet1.GetComponent<bullet7_enemy_sub>().angle = 0 * Mathf.Deg2Rad;
            bullet2.GetComponent<bullet7_enemy_sub>().angle = 45.0f * Mathf.Deg2Rad;
            bullet3.GetComponent<bullet7_enemy_sub>().angle = 90.0f * Mathf.Deg2Rad;
            bullet4.GetComponent<bullet7_enemy_sub>().angle = 135.0f * Mathf.Deg2Rad;
            bullet5.GetComponent<bullet7_enemy_sub>().angle = 180.0f * Mathf.Deg2Rad;
            bullet6.GetComponent<bullet7_enemy_sub>().angle = 225.0f * Mathf.Deg2Rad;
            bullet7.GetComponent<bullet7_enemy_sub>().angle = 270.0f * Mathf.Deg2Rad;
            bullet8.GetComponent<bullet7_enemy_sub>().angle = 315.0f * Mathf.Deg2Rad;
            Destroy(this.gameObject);
        }
        SetVelocity();
    }
}

