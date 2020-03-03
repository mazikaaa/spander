using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Bullet2 : MonoBehaviour
{
    public float angle;
    float speed = 9.0f;
    float deletetime,wavetime;
    float deletespan = 4.0f;
    float wavespan = 0.4f;
    [SerializeField] Rigidbody2D rigidbody2D;
    public GameObject wavePrefab;
    void SetVelocity(float direction, float speed)
    {
        float vx = Mathf.Cos(direction) * speed;
        float vy = Mathf.Sin(direction) * speed;
        rigidbody2D.velocity = new Vector2(vx, vy);
    }
    // Start is called before the first frame update
    void Start()
    {
        SetVelocity(angle, speed);
    }

    // Update is called once per frame
    void Update()
    {
        deletetime += Time.deltaTime;
        wavetime += Time.deltaTime;
        if (deletetime > deletespan)
        {
            Destroy(this.gameObject);
        }

        if (wavetime > wavespan)
        {
            Instantiate(wavePrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            wavetime = 0.0f;
        }

    }
}
