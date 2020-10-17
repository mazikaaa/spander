using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startManager : MonoBehaviour
{
    public GameObject Check, AudioPrefab;
    int attack, HP, speed,shot ,energy, music;
    string item,gamemode;
    bool init = false;
    AudioSource Audio_SE;
    [SerializeField] AudioClip SE_start;
    // Start is called before the first frame update
    void Start()
    {

        music = PlayerPrefs.GetInt("MUSIC", 0);
        if (music == 0)
        {
            GameObject Audio = Instantiate(AudioPrefab);
        }
        Audio_SE = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PushStartButton()
    {
        energy = PlayerPrefs.GetInt("ENERGY", 0);
        attack = PlayerPrefs.GetInt("ATTACKLV", 1);
        HP = PlayerPrefs.GetInt("HPLV", 1);
        speed = PlayerPrefs.GetInt("SPEEDLV", 1);
        shot = PlayerPrefs.GetInt("SHOTLV", 1);
        item = PlayerPrefs.GetString("ITEM", "none");
        if (energy == 0 && attack == 1 && HP == 1 && speed == 1 && item=="none")
        {
            PlayerPrefs.SetInt("MUSIC", 1);
            SceneManager.LoadScene("StageSelect");
        }
        Check.SetActive(true);
    }
    public void PushInitButton()
    {
        PlayerPrefs.SetInt("ENERGY", 0);
        PlayerPrefs.SetInt("HP", 100);
        PlayerPrefs.SetInt("HPLV", 1);
        PlayerPrefs.SetInt("HPENERGY", 600);
        PlayerPrefs.SetInt("HPMAX", 1);
        PlayerPrefs.SetInt("ATTACK", 10);
        PlayerPrefs.SetInt("ATTACKLV", 1);
        PlayerPrefs.SetInt("ATTACKENERGY", 600);
        PlayerPrefs.SetInt("ATTACKMAX", 1);
        PlayerPrefs.SetFloat("SPEED", 5.0f);
        PlayerPrefs.SetInt("SPEEDLV", 1);
        PlayerPrefs.SetInt("SPPEDENERGY", 600);
        PlayerPrefs.SetInt("SPEEDMAX", 1);
        PlayerPrefs.SetFloat("S_S", 7.0f);
        PlayerPrefs.SetFloat("S_T", 5.0f);
        PlayerPrefs.SetInt("SHOTLV", 1);
        PlayerPrefs.SetInt("SHOTENERGY", 600);
        PlayerPrefs.SetInt("SHOTMAX", 1);
        PlayerPrefs.SetString("ITEM", "none");
        PlayerPrefs.SetInt("CLEAR", 0);

        Audio_SE.PlayOneShot(SE_start);
        PlayerPrefs.SetInt("MUSIC", 1);
        Invoke("GoStageSelect", 0.3f);
    }

    public void PushBackButton()
    {
        Check.SetActive(false);
    }
    public void PushContinueButton()
    {
        Audio_SE.PlayOneShot(SE_start);
        PlayerPrefs.SetInt("MUSIC", 1);
        Invoke("GoStageSelect", 0.3f);
    }

    public void PushInformationButton()
    {
        PlayerPrefs.SetInt("MUSIC", 1);
        SceneManager.LoadScene("InformationScene");

    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("MUSIC", 0);
    }

    private void GoStageSelect()
    {
        SceneManager.LoadScene("StageSelect");
    }

}
