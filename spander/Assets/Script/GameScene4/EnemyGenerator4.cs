using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator4 : MonoBehaviour
{
    int i;
    public GameObject[] EnemyPrefab = new GameObject[5];
    float[] EnemyGenerate = new float[5];
    public float[] GenerateTime = { 12.0f, 15.0f,18.0f, 20.0f,25.0f };
    float x, y;
    string gamemode;
    // Start is called before the first frame update
    void Start()
    {
        gamemode = PlayerPrefs.GetString("GAMEMODE", "normal");

        if (gamemode == "normal")
        {
            GenerateTime[0] = 14.0f;
            GenerateTime[2] = 19.0f;
            GenerateTime[3] = 21.0f;
        }

        for (i = 0; i < 3; i++)
        {
            x = Random.Range(-35.0f, 35.0f);
            y = Random.Range(-25.0f, 25.0f);
            GameObject Enemy1 = Instantiate(EnemyPrefab[i], new Vector3(x, y, 0), Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        EnemyGenerate[0] += Time.deltaTime;
        EnemyGenerate[1] += Time.deltaTime;
        EnemyGenerate[2] += Time.deltaTime;
        EnemyGenerate[3] += Time.deltaTime;
        EnemyGenerate[4] += Time.deltaTime;


        if (EnemyGenerate[0] > GenerateTime[0])
        {
            x = Random.Range(-35.0f, 35.0f);
            y = Random.Range(-25.0f, 25.0f);
            GameObject Enemy1 = Instantiate(EnemyPrefab[0], new Vector3(x, y, 0), Quaternion.identity);
            EnemyGenerate[0] = 0;
        }

        if (EnemyGenerate[1] > GenerateTime[1])
        {
            x = Random.Range(-35.0f, 35.0f);
            y = Random.Range(-25.0f, 25.0f);
            GameObject Enemy1 = Instantiate(EnemyPrefab[1], new Vector3(x, y, 0), Quaternion.identity);
            EnemyGenerate[1] = 0;
        }

        if (EnemyGenerate[2] > GenerateTime[2])
        {
            x = Random.Range(-35.0f, 35.0f);
            y = Random.Range(-25.0f, 25.0f);
            GameObject Enemy1 = Instantiate(EnemyPrefab[2], new Vector3(x, y, 0), Quaternion.identity);
            EnemyGenerate[2] = 0;
        }


        if (EnemyGenerate[3] > GenerateTime[3])
        {
            x = Random.Range(-35.0f, 35.0f);
            y = Random.Range(-25.0f, 25.0f);
            GameObject Enemy1 = Instantiate(EnemyPrefab[3], new Vector3(x, y, 0), Quaternion.identity);
            EnemyGenerate[3] = 0;
        }

        if (EnemyGenerate[4] > GenerateTime[4])
        {
            x = Random.Range(-15.0f, 15.0f);
            y = Random.Range(-15.0f, 15.0f);
            GameObject Enemy1 = Instantiate(EnemyPrefab[4], new Vector3(x, y, 0), Quaternion.identity);
            EnemyGenerate[4] = 0;
        }
    }
}
