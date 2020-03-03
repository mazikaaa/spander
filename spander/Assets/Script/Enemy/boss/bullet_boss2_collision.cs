using UnityEngine;

public class bullet_boss2_collision: MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            player.GetComponent<PlayerManager>().Damage(20);
        }
        if (col.gameObject.tag == "barrier.player")
        {
            Destroy(this.gameObject);
        }
    }

}
