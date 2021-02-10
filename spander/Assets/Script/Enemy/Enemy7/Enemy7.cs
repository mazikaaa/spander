using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading.Tasks;

public class Enemy7 : EnemyBase
{
    [SerializeField] GameObject gray_particle,red_particle;
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
    protected override void Destroy()
    {
        Audio.PlayOneShot(SE_explode);
        Instantiate(gray_particle, transform.position, transform.rotation);
        Instantiate(red_particle, transform.position, transform.rotation);
        gameManager.GetComponent<GameManager>().EnergyGet(80);
        Destroy(this.gameObject);
    }

}
