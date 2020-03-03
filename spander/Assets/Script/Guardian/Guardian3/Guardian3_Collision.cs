using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian3_Collision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "bullet.player")
        {
            this.gameObject.GetComponent<Guardian3>().Damage(col.gameObject.GetComponent<bulletManager>().power);
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "wave.player")
        {
            this.gameObject.GetComponent<Guardian3>().Damage(col.gameObject.GetComponent<waveManager>().power);
        }
    }
}
