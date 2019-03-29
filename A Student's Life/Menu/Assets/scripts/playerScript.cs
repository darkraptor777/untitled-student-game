using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Assets.scripts;

public class playerScript : MonoBehaviour
{
    public static playerScript instance = null;
    public int playerHealth = 100;
    public const int maxplayerhealth = 100;
    public int playerDamage = 10;
    int weaponDamage;
    public int totalDamage;
    bool died = false;
    public Text playerDamageText;
    public Slider playerHealthSlider;

    weapon[] weapons = { new weapon("none",0), new weapon("bronze",10), new weapon("iron",15), new weapon("steel",25), new weapon("reinforced steel",40)};
    int equippedweapon = 0;

    void Start()
    {
        
    }

    void Update()
    {
        //weapon calculations
        totalDamage = playerDamage + weapons[equippedweapon].getdmg();

        //switch weapons
        if (Input.GetKeyDown("e")) {
            equippedweapon++;
            if (equippedweapon >= weapons.Length)
                equippedweapon = 0;
            print("Switch Weapons to "+ weapons[equippedweapon].getname());
        }
        //playerDamageText.text = "" + totalDamage;
        playerHealthSlider.value = (playerHealth);

        if (died == true)
        {
            SceneManager.LoadScene("gameOver");
        }
    }

    public void updateDMGText(int dmg)
    {
        playerDamageText.text = "" + dmg;
    }

    public void takedamage(int dmg)
    {
        playerHealth = playerHealth - dmg;
        CheckPlayerDead();
    }
/*
    public void PlayerDamageCalc()
    {
        playerHealth = playerHealth - GameObject.FindWithTag("Enemy").GetComponent<enemyScript>().enemy1Damage;

        PlayerDead();
    }

    public void PlayerDamageCalcDef()
    {
        playerHealth = playerHealth - (GameObject.FindWithTag("Enemy").GetComponent<enemyScript>().enemy1Damage / 2);
        PlayerDead();
    }
    */
    public void CheckPlayerDead()
    {
        if (playerHealth <= 0)
        {
            died = true;
        }    
    }
}