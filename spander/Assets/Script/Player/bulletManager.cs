using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletManager : MonoBehaviour
{
    public int power;
    float angle;
    float speed;
    float deletetime;
    float deletespan;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        power = PlayerPrefs.GetInt("ATTACK", 10);
        player = GameObject.Find("Player");
        angle = player.GetComponent<PlayerManager>().bulletangle;
        speed = PlayerPrefs.GetFloat("S_S", 7.0f);
        deletespan=PlayerPrefs.GetFloat("S_T",5.0f);
        SetVelocity(angle, speed);
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

    void SetVelocity(float direction, float speed)
    {
        float vx = Mathf.Cos(direction) * speed;
        float vy = Mathf.Sin(direction) * speed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(vx, vy);
    }
}
