using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ItemManager : MonoBehaviour
{
    public GameObject AudioPrefab;
    int music,Energy,i;
    GameObject energy_score;
    public GameObject[] buyButtons;
    string item;
    AudioSource Audio_SE;
    [SerializeField] AudioClip SE_Get;

    // Start is called before the first frame update
    void Start()
    {
        Energy = PlayerPrefs.GetInt("ENERGY", 0);
        music = PlayerPrefs.GetInt("MUSIC", 1);
        item= PlayerPrefs.GetString("ITEM", "none");
            if(item=="none")
            for(i=0;i<3;i++)
            buyButtons[i].GetComponent<Button>().interactable = true;
            else
            for (i = 0; i < 3; i++)
            buyButtons[i].GetComponent<Button>().interactable = false;


        if (music == 0)
        {
            GameObject Audio = Instantiate(AudioPrefab);
        }
        energy_score = GameObject.Find("Score");
        energy_score.GetComponent<Text>().text = Energy.ToString();

        Audio_SE = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushGoBackSelect()
    {
        SceneManager.LoadScene("StageSelect");
    }

   /* public void PushBackCostom()
    {
        SceneManager.LoadScene("CostomScene");
    }
    */

    public void BuyHeartButton()
    {
        if (Energy > 3000)
        {
            Audio_SE.PlayOneShot(SE_Get);
            PlayerPrefs.SetString("ITEM", "heart");
            Energy -= 2500;
            energy_score.GetComponent<Text>().text = Energy.ToString();
            PlayerPrefs.SetInt("ENERGY", Energy);
            for (i = 0; i < 3; i++)
                buyButtons[i].GetComponent<Button>().interactable = false;
        }
    }

    public void BuyWaveButton()
    {
        if (Energy > 2500)
        {
            Audio_SE.PlayOneShot(SE_Get);
            PlayerPrefs.SetString("ITEM", "wave");
            Energy -= 3000;
            energy_score.GetComponent<Text>().text = Energy.ToString();
            PlayerPrefs.SetInt("ENERGY", Energy);
            for (i = 0; i < 3; i++)
                buyButtons[i].GetComponent<Button>().interactable = false;
        }
    }
    public void BuyPotionButton()
    {
        
        if (Energy > 4000)
        {
            Audio_SE.PlayOneShot(SE_Get);
            PlayerPrefs.SetString("ITEM", "potion");
            Energy -= 4000;
            energy_score.GetComponent<Text>().text = Energy.ToString();
            PlayerPrefs.SetInt("ENERGY", Energy);
            for (i = 0; i < 3; i++)
                buyButtons[i].GetComponent<Button>().interactable = false;
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("MUSIC", 0);
    }
}
