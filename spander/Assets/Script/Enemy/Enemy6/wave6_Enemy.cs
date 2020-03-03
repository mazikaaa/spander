using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave6_Enemy : MonoBehaviour
{
    float deletetime;
    float deletespan = 8.0f;
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
        transform.localScale=new Vector3(1.0f + deltawide, 1.0f + deltawide, 1.0f);

    }
}
