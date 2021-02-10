using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet8_enemy : BulletBase
{

    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        deletetime += Time.deltaTime;
        if (deletetime > deletespan)
        {
            Destroy(this.gameObject);
        }

    }
}
