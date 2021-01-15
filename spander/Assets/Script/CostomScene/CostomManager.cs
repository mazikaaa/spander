using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CostomManager : MonoBehaviour
{
    int i;
    int HP, Attack,music;
    public int Energy;
    float Speed,shot_speed,shot_time;
   public int HP_energy, Speed_energy, Attack_energy,Shot_energy;
   public int HP_LV = 1, Attack_LV = 1, Speed_LV = 1,Shot_LV=1;
    public int HP_MAX=1, Attack_MAX=1 , Speed_MAX=1,Shot_MAX=1;
    [SerializeField] GameObject[] HP_gauge = new GameObject[8];
    [SerializeField] GameObject[] Attack_gauge = new GameObject[8];
    [SerializeField] GameObject[] Speed_gauge = new GameObject[8];
    [SerializeField] GameObject[] Shot_gauge = new GameObject[8];
    [SerializeField] GameObject[] LV = new GameObject[4];
    [SerializeField] GameObject[] LV_energy = new GameObject[4];
    GameObject energy_score;
    public GameObject AudioPrefab;
    AudioSource Audio_SE;
    [SerializeField] AudioClip SE_Powerup;
    // Start is called before the first frame update
    void Start()
    {
      Energy = PlayerPrefs.GetInt("ENERGY", 0) ;
        HP = PlayerPrefs.GetInt("HP", 100);
        Attack = PlayerPrefs.GetInt("ATTACK", 10);
        Speed = PlayerPrefs.GetFloat("SPEED", 5.0f);
        shot_speed = PlayerPrefs.GetFloat("S_S", 7.0f);
        shot_time = PlayerPrefs.GetFloat("S_T", 5.0f);

        HP_LV = PlayerPrefs.GetInt("HPLV", 1);
        Attack_LV = PlayerPrefs.GetInt("ATTACKLV", 1);
        Speed_LV = PlayerPrefs.GetInt("SPEEDLV", 1);
        Shot_LV = PlayerPrefs.GetInt("SHOTLV", 1);

        HP_energy = PlayerPrefs.GetInt("HPENERGY", 600);
        Attack_energy = PlayerPrefs.GetInt("ATTACKENERGY", 600);
        Speed_energy = PlayerPrefs.GetInt("SPPEDENERGY", 600);
        Shot_energy = PlayerPrefs.GetInt("SHOTENERGY", 600);

        HP_MAX = PlayerPrefs.GetInt("HPMAX", 1);
        Attack_MAX = PlayerPrefs.GetInt("ATTACKMAX", 1);
        Speed_MAX = PlayerPrefs.GetInt("SPEEDMAX", 1);
        Shot_MAX = PlayerPrefs.GetInt("SHOTMAX", 1);

        energy_score = GameObject.Find("Score");

        LV[0].GetComponent<Text>().text = HP_MAX.ToString();
        LV_energy[0].GetComponent<Text>().text = HP_energy.ToString();
        LV[1].GetComponent<Text>().text = Attack_MAX.ToString();
        LV_energy[1].GetComponent<Text>().text = Attack_energy.ToString();
        LV[2].GetComponent<Text>().text = Speed_MAX.ToString();
        LV_energy[2].GetComponent<Text>().text = Speed_energy.ToString();
        LV[3].GetComponent<Text>().text = Shot_MAX.ToString();
        LV_energy[3].GetComponent<Text>().text = Shot_energy.ToString();

        energy_score.GetComponent<Text>().text = Energy.ToString();

        for (i = 1; i <= HP_LV; i++)
        {
            HP_gauge[i - 1].GetComponent<Image>().fillAmount = 1.0f;
        }
        for (i = 1; i <= Attack_LV; i++)
        {
            Attack_gauge[i - 1].GetComponent<Image>().fillAmount = 1.0f;
        }
        for (i = 1; i <= Speed_LV; i++)
        {
            Speed_gauge[i - 1].GetComponent<Image>().fillAmount = 1.0f;
        }
        for (i = 1; i <= Shot_LV; i++)
        {
            Shot_gauge[i - 1].GetComponent<Image>().fillAmount = 1.0f;
        }



        music = PlayerPrefs.GetInt("MUSIC", 1);
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

    public void PushHPplus()
    {
        if (HP_LV == HP_MAX)
        {
            if (Energy > HP_energy)
            {
                Audio_SE.PlayOneShot(SE_Powerup);
                Energy -= HP_energy;
                HP += 25;
                HP_LV += 1;
                HP_MAX += 1;
                HP_energy += 600;
                HP_gauge[HP_LV - 1].GetComponent<Image>().fillAmount = 1.0f;
                LV[0].GetComponent<Text>().text = HP_MAX.ToString();
                LV_energy[0].GetComponent<Text>().text = HP_energy.ToString();
                PlayerPrefs.SetInt("HPMAX", HP_MAX);
                energy_score.GetComponent<Text>().text = Energy.ToString();
            }
        }
        else
        {
            HP += 25;
            HP_LV += 1;
            HP_gauge[HP_LV - 1].GetComponent<Image>().fillAmount = 1.0f;
        }
        PlayerPrefs.SetInt("ENERGY", Energy);
        PlayerPrefs.SetInt("HP",HP);
        PlayerPrefs.SetInt("HPLV", HP_LV);
        PlayerPrefs.SetInt("HPENERGY", HP_energy);
        }


    public void PushAttackplus()
    {

        if (Attack_LV == Attack_MAX)
        {
            if (Energy > Attack_energy)
            {
                Audio_SE.PlayOneShot(SE_Powerup);
                Energy -= Attack_energy;
                Attack += 3;
                Attack_LV += 1;
                Attack_MAX += 1;
                Attack_energy += 600;
                Attack_gauge[Attack_LV - 1].GetComponent<Image>().fillAmount = 1.0f;
                LV[1].GetComponent<Text>().text = Attack_MAX.ToString();
                LV_energy[1].GetComponent<Text>().text = Attack_energy.ToString();
                PlayerPrefs.SetInt("ATTACKMAX", Attack_MAX);
                energy_score.GetComponent<Text>().text = Energy.ToString();
            }
        }
        else
        {
            Attack += 3;
            Attack_LV += 1;
            Attack_gauge[Attack_LV - 1].GetComponent<Image>().fillAmount = 1.0f;
        }
        PlayerPrefs.SetInt("ENERGY", Energy);
        PlayerPrefs.SetInt("ATTACK", Attack);
        PlayerPrefs.SetInt("ATTACKLV", Attack_LV);
        PlayerPrefs.SetInt("ATTACKENERGY", Attack_energy);
    }

    public void PushSpeedplus()
    {
        if (Speed_LV == Speed_MAX)
        {
            if (Energy > Speed_energy)
            {
                Audio_SE.PlayOneShot(SE_Powerup);
                Energy -= Speed_energy;
                Speed += 0.4f;
                Speed_LV += 1;
                Speed_MAX += 1;
                Speed_energy += 600;
                Speed_gauge[Speed_LV - 1].GetComponent<Image>().fillAmount = 1.0f;
                LV[2].GetComponent<Text>().text = Speed_MAX.ToString();
                LV_energy[2].GetComponent<Text>().text = Speed_energy.ToString();
                PlayerPrefs.SetInt("SPEEDMAX", Speed_MAX);
                energy_score.GetComponent<Text>().text = Energy.ToString();
            }
        }
        else
        {
            Speed += 0.4f;
            Speed_LV += 1;
            Speed_gauge[Speed_LV - 1].GetComponent<Image>().fillAmount = 1.0f;
        }
        PlayerPrefs.SetInt("ENERGY", Energy);
        PlayerPrefs.SetFloat("SPEED", Speed);
        PlayerPrefs.SetInt("SPEEDLV", Speed_LV);
        PlayerPrefs.SetInt("SPPEDENERGY", Speed_energy);
    
    }

    public void PushShotplus()
    {
        if (Shot_LV == Shot_MAX)
        {
            if (Energy > Shot_energy)
            {
                Audio_SE.PlayOneShot(SE_Powerup);
                Energy -= Shot_energy;
                shot_speed += 0.25f;
                shot_time += 0.15f;
                Shot_LV += 1;
                Shot_MAX += 1;
                Shot_energy += 600;
                Shot_gauge[Shot_LV - 1].GetComponent<Image>().fillAmount = 1.0f;
                LV[3].GetComponent<Text>().text = Shot_MAX.ToString();
                LV_energy[3].GetComponent<Text>().text = Shot_energy.ToString();
                PlayerPrefs.SetInt("SHOTMAX", Shot_MAX);
                energy_score.GetComponent<Text>().text = Energy.ToString();
            }
        }
        else
        {
            shot_speed += 0.25f;
            shot_time += 0.15f;
            Shot_LV += 1;
            Shot_gauge[Shot_LV - 1].GetComponent<Image>().fillAmount = 1.0f;
        }
        PlayerPrefs.SetInt("ENERGY", Energy);
        PlayerPrefs.SetFloat("S_S", shot_speed);
        PlayerPrefs.SetFloat("S_T", shot_time);
        PlayerPrefs.SetInt("SHOTLV", Shot_LV);
        PlayerPrefs.SetInt("SHOTENERGY", Shot_energy);

    }

    public void PushHPminus()
    {
        if (HP_LV != 1)
        {
            HP_gauge[HP_LV-1].GetComponent<Image>().fillAmount = 0.0f;
            HP_LV -= 1;
            HP -= 25;
        }
        PlayerPrefs.SetInt("HP", HP);
        PlayerPrefs.SetInt("HPLV", HP_LV);
    }

    public void PushAttackminus()
    {
        if (Attack_LV != 1)
        {
            Attack_gauge[Attack_LV - 1].GetComponent<Image>().fillAmount = 0.0f;
            Attack_LV -= 1;
            Attack-= 3;
        }
        PlayerPrefs.SetInt("ATTACK", Attack);
        PlayerPrefs.SetInt("ATTACKLV", Attack_LV);
    }

    public void PushSpeedminus()
    {
        if (Speed_LV != 1)
        {
            Speed_gauge[Speed_LV - 1].GetComponent<Image>().fillAmount = 0.0f;
            Speed_LV -= 1;
            Speed -= 0.3f;
        }
        PlayerPrefs.SetFloat("SPEED", Speed);
        PlayerPrefs.SetInt("SPEEDLV", Speed_LV);
    }

    public void PushShotminus()
    {
        if (Shot_LV != 1)
        {
            Shot_gauge[Shot_LV - 1].GetComponent<Image>().fillAmount = 0.0f;
            Shot_LV -= 1;
            shot_speed -= 0.25f;
            shot_time -= 0.15f;
        }
        PlayerPrefs.SetFloat("S_S", shot_speed);
        PlayerPrefs.SetFloat("S_T", shot_time);
        PlayerPrefs.SetInt("SHOTLV", Shot_LV);
    }


    public void PushGoBackSelect()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void PushGoItem()
    {
        SceneManager.LoadScene("ItemScene");
    }


    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("MUSIC", 0);
    }
}
