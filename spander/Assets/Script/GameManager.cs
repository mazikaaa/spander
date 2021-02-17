using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int HPindex, HPstack, i;
    int HP,HPdalta;
    int EnergyAmount, getEnergy;
    int Clearcount = 0;
    string gamemode, item;
    bool outoshotmode=false,canoutshot=false,cationflag=true;
    public int stageNo;
    public float gameCleartime,barrriertime=0.0f;
    public GameObject[] hpgauge = new GameObject[11];
    public GameObject[] hpgauge_frame = new GameObject[7];
    public GameObject[] item_image;
    public GameObject player,item_frame,barrier, outoshot_text,cation_text;
    AudioSource Audio;
    Animator cat_anim;
    [SerializeField] AudioSource Audio_Manager;
    [SerializeField] AudioClip SE_GameOver,SE_GameClear,Time_SE;

    GameObject time, timetext, energy, energy_text, HP_text,Debug;
    public GameObject gameClear, gameOver;

    // Start is called before the first frame update
    void Start()
    {
        //データ関連
        getEnergy = 0;
        EnergyAmount = PlayerPrefs.GetInt("ENERGY", 0);
        gamemode = PlayerPrefs.GetString("GAMEMODE", "normal");
        if (gamemode == "normal")
        {
            gameCleartime -= 20.0f;
            canoutshot = true;
        }
        
        time = GameObject.Find("GameClear_Time");
        timetext = GameObject.Find("GameClear_Text");
        energy = GameObject.Find("Energy_Score");
        energy_text = GameObject.Find("Energy");
        HP_text = GameObject.Find("HP");

        //アイテム関連
        item = PlayerPrefs.GetString("ITEM", "none");
        for (i = 0; i < 3; i++)
        {
            item_image[i].SetActive(false);
        }
        if (item == "heart")
        {
            item_image[0].SetActive(true);
        }
        else if (item == "potion")
        {
            item_image[1].SetActive(true);
        }
        else if (item == "wave")
        {
            item_image[2].SetActive(true);
        }


        //ゲージ関連（HPに対応してゲージを減らす）
        HP = PlayerPrefs.GetInt("HP", 100);
        /*Debug = GameObject.Find("Debug");
        Debug.GetComponent<Text>().text = HP.ToString("F1");*/
        HPindex = HP / 25;

        for (i = HPindex; i > 4; i--)
        {
            hpgauge_frame[i - 5].SetActive(true);
        }

        //BGM関連
        Audio = GetComponent<AudioSource>();

        //アニメーション関連
        cat_anim = cation_text.GetComponent<Animator>();

    }



    // Update is called once per frame
    void Update()
    {
        gameCleartime -= Time.deltaTime;

        //アイテムのバリアを使った時、アイテムの使用時間を制御する
        if (barrriertime > 0.0f)
        {
            barrier.SetActive(true);
            barrriertime -= Time.deltaTime;
        }
        else if (barrriertime < 0.0f)
        {
            player.GetComponent<PlayerManager>().DeleteBarrier();
            barrier.SetActive(false);
            barrriertime = 0.0f;
        }

        

        time.GetComponent<Text>().text = gameCleartime.ToString("F2");
        energy.GetComponent<Text>().text = getEnergy.ToString();
        barrier.GetComponent<Text>().text = barrriertime.ToString();

        if (gameCleartime < 0.0f)
        {
            if (Clearcount == 0)
            {
                GameClear();
                Clearcount = 1;
            }

        }

        //
        if (gameCleartime < 30.0f&&cationflag)
        {
            CationTime();
            Audio.volume = 0.3f;
            Audio.PlayOneShot(Time_SE);
            time.GetComponent<Text>().color = new Vector4(255, 140, 0, 255);
            cationflag = false;
        }

        HPstack = HP / 25;
        HP = player.GetComponent<PlayerManager>().HP;
        if (HPstack != HP / 25)
        {
            HPdalta = HPstack - HP / 25;
            if (HPdalta == 1)
            {
                hpgauge[HP / 25 + 1].GetComponent<Image>().fillAmount = 0.0f;
            }
            else if (HPdalta == 2)
            {
                hpgauge[HP / 25 + 1].GetComponent<Image>().fillAmount = 0.0f;
                hpgauge[HP / 25 + 2].GetComponent<Image>().fillAmount = 0.0f;
            }
            else if (HPdalta == 3)
            {
                hpgauge[HP / 25 + 1].GetComponent<Image>().fillAmount = 0.0f;
                hpgauge[HP / 25 + 2].GetComponent<Image>().fillAmount = 0.0f;
                hpgauge[HP / 25 + 3].GetComponent<Image>().fillAmount = 0.0f;
            }
        }
        hpgauge[HP / 25].GetComponent<Image>().fillAmount = 0.04f * (HP % 25);

        //オートショットモードに切り替える
        if (Input.GetKeyDown(KeyCode.D) && canoutshot)
        {
            if (outoshotmode)
            {
                player.GetComponent<PlayerManager>().ActiveOutMode(false);
                outoshotmode = false;
                outoshot_text.SetActive(false);
            }
            else
            {
                player.GetComponent<PlayerManager>().ActiveOutMode(true);
                outoshotmode = true;
                outoshot_text.SetActive(true);
            }
        }
     
    }
    //エネルギーを獲得する関数
    public void EnergyGet(int Energy)
    {
        getEnergy += Energy;
    }
    void GoBackStageSelect()
    {
        PlayerPrefs.SetInt("MUSIC", 0);
        SceneManager.LoadScene("StageSelect");
    }
    //ゲームオーバー処理
    public void GameOver()
    {
        gameCleartime = 100.0f;
        EnergyAmount += getEnergy;
        PlayerPrefs.SetInt("ENERGY", EnergyAmount);
        time.SetActive(false);
        timetext.SetActive(false);
        energy_text.SetActive(false);
        energy.SetActive(false);
        HP_text.SetActive(false);
        item_frame.SetActive(false);
        outoshot_text.SetActive(false);
        gameOver.SetActive(true);

        Audio_Manager.GetComponent<AudioSource>().volume=0.03f;
        Audio.PlayOneShot(SE_GameOver);

        var clones = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }

        GameObject player = GameObject.Find("Player");
        Destroy(player);

        Invoke("GoBackStageSelect", 3.0f);

    }
    //ゲームクリア処理
    public void GameClear()
    {
        EnergyAmount += getEnergy;
        PlayerPrefs.SetInt("ENERGY", EnergyAmount);
        time.SetActive(false);
        timetext.SetActive(false);
        energy_text.SetActive(false);
        energy.SetActive(false);
        HP_text.SetActive(false);
        item_frame.SetActive(false);
        outoshot_text.SetActive(false);
        gameClear.SetActive(true);

        Audio_Manager.GetComponent<AudioSource>().volume = 0.03f;
        Audio.volume = 0.30f;
        Audio.PlayOneShot(SE_GameClear);

        var clones = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }

        GameObject player = GameObject.Find("Player");
        Destroy(player);


        if (PlayerPrefs.GetInt("CLEAR", 0) < stageNo)
        {
            PlayerPrefs.SetInt("CLEAR", stageNo);
        }
        Invoke("GoBackStageSelect", 3.0f);
    }

    public void itemfalse(int i)
    {
        item_image[i].SetActive(false);
    }

    //ゲームクリアまでの時間が近くなっていることを知らせる警告を出す
    private void CationTime()
    {
        cation_text.GetComponent<Text>().text = "30.00";
        cat_anim.SetTrigger("Cation");
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("MUSIC", 0);
    }


}