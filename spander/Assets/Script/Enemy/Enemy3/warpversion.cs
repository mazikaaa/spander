using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpversion : MonoBehaviour
{
    float warpspan = 1.5f;
    float warptime;
    float randomx, randomy;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        warptime += Time.deltaTime;
        if (warptime > warpspan)
        {
            randomx = Random.Range(-4.0f, 4.0f);
            randomy = Random.Range(-4.0f, 4.0f);
            transform.position = new Vector3(transform.position.x + randomx, transform.position.y, 0);
            warptime = 0.0f;
        }
    }
}
