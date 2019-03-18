using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enemyScript : MonoBehaviour
{
    public static enemyScript instance = null;
    public int enemy1Health = 30;
    public const int maxenemy1Health = 30;
    public int enemy1Damage = 10;
    bool wonEncounter = false;

    public Slider enemyHealthSlider;

    void Start()
    {
        enemyHealthSlider.maxValue = maxenemy1Health;
    }

    void Update()
    {
        enemyHealthSlider.value = (enemy1Health);

        if (wonEncounter)
        {
            SceneManager.LoadScene("overWorld_01");
        }
    }

    public void EnemyDamageCalc()
    {
        enemy1Health = enemy1Health - GameObject.FindWithTag("Player").GetComponent<playerScript>().totalDamage;
        enemyDead();
    }

    public void enemyDead()
    {
        if(enemy1Health<=0)
        {
            wonEncounter = true;
        }
    }
}
