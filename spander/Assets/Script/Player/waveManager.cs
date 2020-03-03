using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveManager : MonoBehaviour
{
    float deletetime;
    float deletespan = 4.0f;
    float deltawide = 0.0f;
    public int power = 200;
    int count=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deletetime += Time.deltaTime;
        if (deletetime > deletespan)
        {
            Destroy(this.gameObject);
        }

        if (deletetime > 1.0f && count==0)
        {
            power -= 25;
            count += 1;
            Debug.Log(power);
        }
        else if (deletetime > 2.0f && count == 1)
        {
            power -= 25;
            count += 1;
            Debug.Log(power);
        }
        else if (deletetime > 3.0f && count == 2)
        {
            power -= 25;
            count += 1;
            Debug.Log(power);
        }



        deltawide += 0.07f;
        transform.localScale = new Vector3(1.0f + deltawide, 1.0f + deltawide, 1.0f);
    }
}
