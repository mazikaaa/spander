using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Wave : MonoBehaviour
{
    float deletetime;
    float deletespan = 1.2f;
    float deltawide = 0.0f;
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

        deltawide += 0.03f;
        transform.localScale = new Vector3(0.7f + deltawide, 0.7f + deltawide, 1.0f);
    }
}
