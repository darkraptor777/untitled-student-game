using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Assets.scripts;

public class playerScript : MonoBehaviour
{
	
    public GameObject saveObject;
    private SaveInfoScript saveInfo;
	public WorldSaveScript worldInfo;
    public static playerScript instance = null;
    public int playerHealth = 100;
    public int maxplayerhealth = 100;
    public int playerDamage = 10;
    int weaponDamage;
    public int totalDamage;
    bool died = false;
    public Text playerDamageText;
    public Slider playerHealthSlider;

    weapon[] weapons = { new weapon("none",0), new weapon("bronze",10), new weapon("iron",15), new weapon("steel",25), new weapon("reinforced steel",40)};
    int [] armour = { 100, 125, 150, 175, 200 };

    int equippedweapon = 0;

    void Start()
    {
        saveInfo=saveObject.GetComponent<SaveInfoScript>();
		worldInfo=saveObject.GetComponent<WorldSaveScript>();
		transform.position.x=worldInfo.playerX;
		transform.position.y=worldInfo.playerY;
        playerHealth = saveInfo.Health;
        maxplayerhealth = armour[saveInfo.ArmourTier];
        playerHealthSlider.maxValue = maxplayerhealth;
        equippedweapon = saveInfo.WeaponTier;
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