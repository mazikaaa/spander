using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenarator_2 : MonoBehaviour
{
    int i;
    public GameObject[] EnemyPrefab = new GameObject[4];
    float[] EnemyGenerate = new float[4];
    public float[] GenerateTime = { 9.0f, 11.0f, 14.0f,17.0f };
    float x, y;
    string gamemode;
    // Start is called before the first frame update
    void Start()
    {
        gamemode = PlayerPrefs.GetString("GAMEMODE", "normal");

        if (gamemode == "normal")
        {
            GenerateTime[0] = 10.0f;
            GenerateTime[1] = 13.0f;
            GenerateTime[2] = 15.0f;
        }

        for (i = 0; i < 4; i++)
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
    }
}
