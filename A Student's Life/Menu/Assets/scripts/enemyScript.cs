using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enemyScript : MonoBehaviour
{
    public GameObject saveObject;
    private SaveInfoScript saveInfo;
    public static enemyScript instance = null;
    public string enemyName;
    public int enemyHealth = 30;
    public const int maxenemyHealth = 30;
    public int enemyDamage = 10;
    bool wonEncounter = false;
    public Text enemyDamageText;
    public Slider enemyHealthSlider;
    public GameObject ptext;

    public int bounty;

    void Start()
    {
        saveInfo = saveObject.GetComponent<SaveInfoScript>();
        enemyHealthSlider.maxValue = maxenemyHealth;
        enemyHealthSlider.GetComponentInChildren<Text>().text = enemyName;
    }

    void Update()
    {
        enemyHealthSlider.value = (enemyHealth);
        //enemyDamageText.text = "" + enemyDamage;

        if (wonEncounter)
        {
            saveInfo.Save();
            SceneManager.LoadScene("overWorld_01");
        }
    }

    public void takedamage(int dmg)
    {
        enemyHealth = enemyHealth - dmg;
        CheckEnemyDead();
    }
    public void updateDMGText(int dmg)
    {
        enemyDamageText.text = "" + dmg;
    }
    /*
    public void EnemyDamageCalc()
    {
        enemyHealth = enemyHealth - GameObject.FindWithTag("Player").GetComponent<playerScript>().totalDamage;
        CheckEnemyDead();
    }
    */
    public void CheckEnemyDead()
    {
        if(enemyHealth<=0)
        {
            wonEncounter = true;
            saveInfo.Money += bounty;
        }
    }
}
