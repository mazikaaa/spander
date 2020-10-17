using UnityEngine;

public class Enemy2_Collision : MonoBehaviour
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
            this.gameObject.GetComponent<Enemy2>().Damage(col.gameObject.GetComponent<bulletManager>().power);
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "wave.player")
        {
            this.gameObject.GetComponent<Enemy2>().Damage(col.gameObject.GetComponent<waveManager>().power);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerManager>().Damage(20);
            this.gameObject.GetComponent<Enemy2>().destroy();
        }
    }
}
