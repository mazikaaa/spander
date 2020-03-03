using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Information: MonoBehaviour
{
    public GameObject[] scene = new GameObject[7];
    public GameObject AudioPrefab;
    public GameObject boss_hint;
    int music,clearStageNo;
    // Start is called before the first frame update
    void Start()
    {

        music = PlayerPrefs.GetInt("MUSIC", 1);
        if (music == 0)
        {
            GameObject Audio = Instantiate(AudioPrefab);
        }
        clearStageNo = PlayerPrefs.GetInt("CLEAR", 0);

        clearStageNo = 0;
    }

// Update is called once per frame
void Update()
    {
        
    }

    public void PushStart()
    {
        scene[1].SetActive(false);
        scene[0].SetActive(true);
    }

    public void PushStartScene()
    {
        scene[2].SetActive(false);
        scene[0].SetActive(false);
        scene[1].SetActive(true);
    }

    public void PushselectScene()
    {
        scene[3].SetActive(false);
        scene[1].SetActive(false);
        scene[2].SetActive(true);
    }

    public void PushgameScene()
    {
        scene[6].SetActive(false);
        scene[2].SetActive(false);
        scene[3].SetActive(true);
    }
    public void Pushope()
    {
        scene[3].SetActive(false);
        scene[4].SetActive(false);
        scene[6].SetActive(true);
    }

    public void PushcostomScene()
    {
        scene[6].SetActive(false);
        scene[7].SetActive(false);
        scene[4].SetActive(true);
    }

    public void PushitemScene()
    {
        scene[4].SetActive(false);
        scene[5].SetActive(false);
        scene[7].SetActive(true);
    }

    public void Pushend()
    {
        if (clearStageNo >= 3)
        {
            boss_hint.SetActive(true);
        }
        scene[7].SetActive(false);
        scene[5].SetActive(true);
    }

   
    public void GoBackStart()
    {
        PlayerPrefs.SetInt("MUSIC", 1);
        SceneManager.LoadScene("StartScene");
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("MUSIC", 0);
    }
}
