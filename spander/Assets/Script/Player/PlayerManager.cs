using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int stageNo;
    Rigidbody2D player;
    float verkey, horikey;
    public int HP,HPMAX;
    public float speed=5.2f;
    public GameObject bulletPrefab,barrier,wavePrefab;
    GameObject gamemanager;
    AudioSource Audio;
    [SerializeField] GameObject player_particle,yellow_particle;
    [SerializeField]AudioClip SE_shot, SE_heart, SE_barrier, SE_wave;
    public float bulletspeed=7.0f;
    public float bulletangle;
    string itemflag;

    public enum MOVE
    {
        U_L,U_M,U_R,M_L,M_M,M_R,D_L,D_M,D_R,STOP,
    }
    // Start is called before the first frame update
    void Start()
    {
        HP = PlayerPrefs.GetInt("HP", 100);
        HPMAX = HP;
        speed = PlayerPrefs.GetFloat("SPEED", 5.0f);

        player = GetComponent<Rigidbody2D>();
        Audio = GetComponent<AudioSource>();
        gamemanager = GameObject.Find("GameManager");

    }

    // Update is called once per frame
    void Update()
    {
        horikey = 0;
        verkey = 0;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            verkey = 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            verkey = -1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horikey = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            horikey = 1;
        }

        player.velocity = new Vector2(speed * horikey, speed * verkey);


        if (Input.GetKeyDown(KeyCode.W))
        {
            Audio.volume = 0.1f;
            GameObject bullet = Instantiate(bulletPrefab, new Vector2(transform.position.x - 0.5f, transform.position.y+0.5f), Quaternion.Euler(0.0f, 0.0f, 45));
            bulletangle = Mathf.PI*3/4;
            Audio.PlayOneShot(SE_shot);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Audio.volume = 0.1f;
            GameObject bullet = Instantiate(bulletPrefab, new Vector2(transform.position.x , transform.position.y+1.0f), Quaternion.Euler(0.0f, 0.0f, 0));
            bulletangle =Mathf.PI/2;
            Audio.PlayOneShot(SE_shot);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Audio.volume = 0.1f;
            GameObject bullet = Instantiate(bulletPrefab, new Vector2(transform.position.x +0.5f, transform.position.y+0.5f), Quaternion.Euler(0.0f, 0.0f, 315));
            bulletangle = Mathf.PI/4;
            Audio.PlayOneShot(SE_shot);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Audio.volume = 0.1f;
            GameObject bullet = Instantiate(bulletPrefab, new Vector2(transform.position.x - 1.1f, transform.position.y), Quaternion.Euler(0.0f, 0.0f, 270));
            bulletangle =Mathf.PI;
            Audio.PlayOneShot(SE_shot);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            Audio.volume = 0.1f;
            GameObject bullet = Instantiate(bulletPrefab, new Vector2(transform.position.x + 1.1f, transform.position.y), Quaternion.Euler(0.0f, 0.0f, 90));
            bulletangle = 0.0f;
            Audio.PlayOneShot(SE_shot);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            Audio.volume = 0.1f;
            GameObject bullet = Instantiate(bulletPrefab, new Vector2(transform.position.x-0.5f, transform.position.y-0.5f), Quaternion.Euler(0.0f, 0.0f, 135));
            bulletangle = Mathf.PI*5/4;
            Audio.PlayOneShot(SE_shot);
        }
        else if (Input.GetKeyDown(KeyCode.C)|| Input.GetKeyDown(KeyCode.D))
        {
            Audio.volume = 0.1f;
            GameObject bullet = Instantiate(bulletPrefab, new Vector2(transform.position.x, transform.position.y-1.0f), Quaternion.Euler(0.0f, 0.0f, 180));
            bulletangle = -Mathf.PI/2;
            Audio.PlayOneShot(SE_shot);

        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            Audio.volume = 0.1f;
            GameObject bullet = Instantiate(bulletPrefab, new Vector2(transform.position.x+0.5f, transform.position.y-0.5f), Quaternion.Euler(0.0f, 0.0f, 225));
            bulletangle = Mathf.PI*7/4;
            Audio.PlayOneShot(SE_shot);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            itemflag = PlayerPrefs.GetString("ITEM", "none");
            if(itemflag=="heart")
            {
                if (HP + 50 >= HPMAX)
                    HP = HPMAX;
                else
                    HP = HP + 50;

                Audio.volume = 0.5f;
                Audio.PlayOneShot(SE_heart);
                PlayerPrefs.SetString("ITEM", "none");
                if (stageNo == 4)
                {
                    gamemanager.GetComponent<boss_Game>().itemfalse(0);
                }
                else
                {
                    gamemanager.GetComponent<GameManager>().itemfalse(0);
                }
            }
            else if(itemflag == "potion")
            {
                Audio.volume = 0.5f;
                Audio.PlayOneShot(SE_barrier);
                gamemanager.GetComponent<GameManager>().barrriertime = 10.0f;
                barrier.SetActive(true);
                PlayerPrefs.SetString("ITEM", "none");
                if (stageNo == 4)
                {
                    gamemanager.GetComponent<boss_Game>().itemfalse(1);
                }
                else
                {
                    gamemanager.GetComponent<GameManager>().itemfalse(1);
                }
            }
            else if(itemflag=="wave")
            {
                Audio.volume = 0.5f;
                Audio.PlayOneShot(SE_wave);
                GameObject wave = Instantiate(wavePrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                PlayerPrefs.SetString("ITEM", "none");
                if (stageNo == 4)
                {
                    gamemanager.GetComponent<boss_Game>().itemfalse(2);
                }
                else
                {
                    gamemanager.GetComponent<GameManager>().itemfalse(2);
                }
            }


        }

        if (HP <= 0)
        {
            Instantiate(player_particle, transform.position, transform.rotation);
            Instantiate(yellow_particle, transform.position, transform.rotation);

            if (stageNo == 4)
            {
                gamemanager.GetComponent<boss_Game>().GameOver();
            }
            else
            {
                gamemanager.GetComponent<GameManager>().GameOver();
            }
        }
    }

    public void Damage(int damage)
    {
        HP -= damage;
    }

    public void DeleteBarrier()
    {
        barrier.SetActive(false);
    }

}
