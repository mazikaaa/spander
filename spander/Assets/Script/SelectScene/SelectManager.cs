using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;

public class SelectManager: MonoBehaviour
{
   int music,i;
    string item;
    public GameObject[] stageButtons; //ステージ選択ボタン配列
    public GameObject[] item_image;
    public GameObject AudioPrefab;
    AudioSource Audio_SE;
    [SerializeField] AudioClip SE_select,SE_Cos;
    // Use this for initialization
    void Start()
    {
       int clearStageNo = PlayerPrefs.GetInt("CLEAR", 0); //どのステージまでクリアしているのかをロード（セーブされていなければ「０」）

        Debug.Log(clearStageNo);
        if (clearStageNo >= 3)
        {
            stageButtons[3].SetActive(true);
        }

        //ステージボタンを有効化
        for (int i = 0; i <= stageButtons.GetUpperBound(0); i++)
        {
            bool buttonEnable;

            if (clearStageNo < i)
            {
                buttonEnable = false;   //前ステージをクリアしていなければ無効
            }
            else
            {
                buttonEnable = true;    //前ステージをクリアしていれば有効
            }

            stageButtons[i].GetComponent<Button>().interactable = buttonEnable; //ボタンの有効/無効を設定
        }
        //音楽の有無を判定
        music = PlayerPrefs.GetInt("MUSIC", 1);
        if (music == 0)
        {
            GameObject Audio = Instantiate(AudioPrefab);
            PlayerPrefs.SetInt("MUSIC", 1);
        }

        item = PlayerPrefs.GetString("ITEM", "none");
        print(item);

        for(i=0;i<3;i++)
        {
            item_image[i].SetActive(false);
        }
        if (item == "heart")
        {
            item_image[0].SetActive(true);
        }
        else if(item=="potion")
        {
            item_image[1].SetActive(true);
        }
        else if(item=="wave")
        {
            item_image[2].SetActive(true);
        }

        //効果音を操作
        Audio_SE = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //ステージ選択ボタンを押した
    public async void PushStageSelectButton(int stageNo)
    {
        Audio_SE.PlayOneShot(SE_select);
        await Task.Delay(100);
        SceneManager.LoadScene("GameScene" + stageNo); //ゲームシーンへ
    }

    public async void PushCostomSelectButton()
    {
        Audio_SE.volume = 0.30f;
        Audio_SE.PlayOneShot(SE_Cos);
        await Task.Delay(100);
        SceneManager.LoadScene("CostomScene");
    }
    public async void PushItemSelectButton()
    {
        Audio_SE.volume = 0.30f;
        Audio_SE.PlayOneShot(SE_Cos);
        await Task.Delay(100);
        SceneManager.LoadScene("ItemScene");
    }


    public void PushBackStart()
    {
        SceneManager.LoadScene("StartScene");
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("MUSIC", 0);
    }


}
