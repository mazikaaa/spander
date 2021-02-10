using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemyBase
{
    private float rollAngle=0.0f;

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
}
