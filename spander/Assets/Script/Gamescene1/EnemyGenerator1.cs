using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator1 : MonoBehaviour
{
    int i;
    public GameObject[] EnemyPrefab = new GameObject[3];
    float[] EnemyGenerate =new float[3];
    public float[] GenerateTime = { 8.0f, 12.0f, 17.0f };
    float x, y;
    string gamemode;
    // Start is called before the first frame update
    void Start()
    {
        gamemode = PlayerPrefs.GetString("GAMEMODE", "normal");

        if (gamemode == "normal")
        {
            GenerateTime[0] = 10.0f;
            GenerateTime[1] = 14.0f;
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

        if (EnemyGenerate[0] > GenerateTime[0])
        {
            x = Random.Range(-35.0f, 35.0f);
            y = Random.Range(-25.0f, 25.0f);
            GameObject Enemy1 = Instantiate(EnemyPrefab[0], new Vector3(x, y,0),Quaternion.identity);
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


    }
}
