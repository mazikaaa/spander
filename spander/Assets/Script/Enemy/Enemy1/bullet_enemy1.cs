using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_enemy1 : BulletBase
{
    // Start is called before the first frame update
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
