using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Guardian_bullet : MonoBehaviour
{
    public float angle, newangle;
    float speed = 9.0f;
    float deletetime;
    float deletespan = 2.0f;
    [SerializeField] GameObject wavePrefab;
    [SerializeField] Rigidbody2D rigidbody2D;
    GameObject player;
    void SetVelocity(float direction, float speed)
    {
        float vx = Mathf.Cos(direction * Mathf.Deg2Rad) * speed;
        float vy = Mathf.Sin(direction * Mathf.Deg2Rad) * speed;
        rigidbody2D.velocity = new Vector2(vx, vy);
    }

    float Direction
    {
        get { return Mathf.Atan2(rigidbody2D.velocity.y, rigidbody2D.velocity.x) * Mathf.Rad2Deg; }
    }
    // Start is called before the first frame update
    void Start()
    {
        SetVelocity(angle, speed);
        player = GameObject.Find("Player");
        newangle = angle;
    }

    // Update is called once per frame
    void Update()
    {

        // プレイヤーと炎の座標所得
        Vector2 next = player.transform.position;
        Vector2 now = transform.position;
        // 目的となる角度を取得する
        Vector2 d = next - now;

        float targetAngle = Mathf.Atan2(d.y, d.x) * Mathf.Rad2Deg;
        newangle = Direction;
        float deltaangle = Mathf.DeltaAngle(newangle, targetAngle);

        if (Mathf.Abs(deltaangle) < 2.0f)
        {
            ;
        }
        else if (deltaangle > 0)
        {
            newangle += 2.0f;
        }
        else
        {
            newangle -= 2.0f;
        }

        SetVelocity(newangle, speed);
        deletetime += Time.deltaTime;
        if (deletetime > deletespan)
        {
            GameObject wave = Instantiate(wavePrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(this.gameObject);
        }
    }
}
