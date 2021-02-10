using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading.Tasks;

public class Enemy3 : EnemyBase
{
  
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
    
}
