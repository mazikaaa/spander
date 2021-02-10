using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading.Tasks;

public class Enemy6 : EnemyBase
{

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
            GameObject wave = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, targetangle - 90)));
            shottime = 0;
        }

    }
}
