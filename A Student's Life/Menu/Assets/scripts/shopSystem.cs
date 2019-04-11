using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopSystem : MonoBehaviour
{
    public GameObject SaveObject;
    //player gold amount
    int playerGold;

    //selection variables
    public GameObject wep;
    public GameObject arm;
    public GameObject boo;
    public GameObject sp;
    public GameObject mp;
    public GameObject lp;
    int currVar = 1;
    bool toggle = true;

    //weapon bools
    bool noWeapon = true;
    bool bronzeSwordUp = false;
    bool ironSwordUp = false;
    bool steelSwordUp = false;
    bool rsteelSwordUp = false;
    int swordCost = 100;

    //armour bools
    bool noArmour = true;
    bool bronzeArmourUp = false;
    bool ironArmourUp = false;
    bool steelArmourUp = false;
    bool rsteelArmourUp = false;
    int armourCost = 100;

    //boots prices
    bool noBoots = true;
    bool boots1Up = false;
    bool boots2Up = false;
    bool boots3Up = false;
    bool boots4Up = false;
    int bootsCost = 50;


    //potions prices
    int potSCost = 50;
    int potSAmount;
    int potMCost = 100;
    int potMAmount;
    int potLCost = 200;
    int potLAmount;

    //displaying text
    public Text smallpotionAmount;
    public Text mediumpotionAmount;
    public Text largepotionAmount;
	public Text weaponCostText;
	public Text armourCostText;
	public Text bootsCostText;
    public Text playerMoney;

    void Start()
    {
        playerGold=SaveObject.GetComponent<SaveInfoScript>().Money;
    }

    void Update()
    {
        weaponCostText.text = "" + swordCost;
        armourCostText.text = "" + armourCost;
        bootsCostText.text = "" + bootsCost;

        smallpotionAmount.text = "" + potSAmount;
        mediumpotionAmount.text = "" + potMAmount;
        largepotionAmount.text = "" + potLAmount;
        playerMoney.text = playerGold + " Gold";

        if (toggle == true)
        {
            StartCoroutine(Toggling());
            if (currVar == 1)
            {
                wep.SetActive(true);
                arm.SetActive(false);
                boo.SetActive(false);
                sp.SetActive(false);
                mp.SetActive(false);
                lp.SetActive(false);
            }
            if (currVar == 2)
            {
                wep.SetActive(false);
                arm.SetActive(true);
                boo.SetActive(false);
                sp.SetActive(false);
                mp.SetActive(false);
                lp.SetActive(false);
            }
            if (currVar == 3)
            {
                wep.SetActive(false);
                arm.SetActive(false);
                boo.SetActive(true);
                sp.SetActive(false);
                mp.SetActive(false);
                lp.SetActive(false);
            }
            if (currVar == 4)
            {
                wep.SetActive(false);
                arm.SetActive(false);
                boo.SetActive(false);
                sp.SetActive(true);
                mp.SetActive(false);
                lp.SetActive(false);
            }
            if (currVar == 5)
            {
                wep.SetActive(false);
                arm.SetActive(false);
                boo.SetActive(false);
                sp.SetActive(false);
                mp.SetActive(true);
                lp.SetActive(false);
            }
            if (currVar == 6)
            {
                wep.SetActive(false);
                arm.SetActive(false);
                boo.SetActive(false);
                sp.SetActive(false);
                mp.SetActive(false);
                lp.SetActive(true);
            }
        }


        //weapon buying selection
        if (Input.GetKeyDown("space") && currVar == 1 && noWeapon)
        {
            if (playerGold >= swordCost)
            {
                playerGold = playerGold - swordCost;
                swordCost = swordCost + 100;
                noWeapon = false;
                bronzeSwordUp = true;
            }
        }
        else if (Input.GetKeyDown("space") && currVar == 1 && bronzeSwordUp)
        {
            if (playerGold >= swordCost)
            {
                playerGold = playerGold - swordCost;
                swordCost = swordCost + 300;
                bronzeSwordUp = false;
                ironSwordUp = true;
            }
        }
        else if (Input.GetKeyDown("space") && currVar == 1 && ironSwordUp)
        {
            if (playerGold >= swordCost)
            {
                playerGold = playerGold - swordCost;
                swordCost = swordCost + 500;
                ironSwordUp = false;
                steelSwordUp = true;
            }
        }
        else if (Input.GetKeyDown("space") && currVar == 1 && steelSwordUp)
        {
            if (playerGold >= swordCost)
            {
                playerGold = playerGold - swordCost;
                steelSwordUp = false;
                rsteelSwordUp = true;
            }
        }
        else if (Input.GetKeyDown("space") && currVar == 1 && rsteelSwordUp)
        {

        }


        //armour buying selection
        if (Input.GetKeyDown("space") && currVar == 2 && noArmour)
        {
            if (playerGold >= armourCost)
            {
                playerGold = playerGold - armourCost;
                armourCost = armourCost + 100;
                noArmour = false;
                bronzeArmourUp = true;
            }
        }
        else if (Input.GetKeyDown("space") && currVar == 2 && bronzeArmourUp)
        {
            if (playerGold >= armourCost)
            {
                playerGold = playerGold - armourCost;
                armourCost = armourCost + 300;
                bronzeArmourUp = false;
                ironArmourUp = true;
            }
        }
        else if (Input.GetKeyDown("space") && currVar == 2 && ironArmourUp)
        {
            if (playerGold >= armourCost)
            {
                playerGold = playerGold - armourCost;
                armourCost = armourCost + 500;
                ironArmourUp = false;
                steelArmourUp = true;
            }
        }
        else if (Input.GetKeyDown("space") && currVar == 2 && steelArmourUp)
        {
            if (playerGold >= armourCost)
            {
                playerGold = playerGold - armourCost;
                steelArmourUp = false;
                rsteelArmourUp = true;
            }
        }
        else if (Input.GetKeyDown("space") && currVar == 2 && rsteelArmourUp)
        {

        }


        //boots buying selection
        if (Input.GetKeyDown("space") && currVar == 3 && noBoots)
        {
            if (playerGold >= bootsCost)
            {
                playerGold = playerGold - bootsCost;
                bootsCost = bootsCost + 50;
                noBoots = false;
                boots1Up = true;
            }
        }
        else if (Input.GetKeyDown("space") && currVar == 3 && boots1Up)
        {
            if (playerGold >= bootsCost)
            {
                playerGold = playerGold - bootsCost;
                bootsCost = bootsCost + 50;
                boots1Up = false;
                boots2Up = true;
            }
        }
        else if (Input.GetKeyDown("space") && currVar == 3 && boots2Up)
        {
            if (playerGold >= bootsCost)
            {
                playerGold = playerGold - bootsCost;
                bootsCost = bootsCost + 100;
                boots2Up = false;
                boots3Up = true;
            }
        }
        else if (Input.GetKeyDown("space") && currVar == 3 && boots3Up)
        {
            if (playerGold >= bootsCost)
            {
                playerGold = playerGold - bootsCost;
                boots3Up = false;
                boots4Up = true;
            }
        }
        else if (Input.GetKeyDown("space") && currVar == 3 && boots4Up)
        {

        }


        //potion buying selection
        if (Input.GetKeyDown("space") && currVar == 4)
        {
            if (playerGold >= potSCost)
            {
                playerGold = playerGold - potSCost;
                potSAmount++;
            }
        }
        if (Input.GetKeyDown("space") && currVar == 5)
        {
            if (playerGold >= potMCost)
            {
                playerGold = playerGold - potMCost;
                potMAmount++;
            }
        }
        if (Input.GetKeyDown("space") && currVar == 6)
        {
            if (playerGold >= potLCost)
            {
                playerGold = playerGold - potLCost;
                potLAmount++;
            }
        }
    }

    IEnumerator Toggling()
    {
        toggle = false;
        if (Input.GetAxis("Horizontal") > 0)
        {
            currVar++;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            currVar--;
        }
        if (currVar > 6)
            currVar = 1;
        if (currVar < 1)
            currVar = 6;

        yield return new WaitForSeconds(0.2f);
        toggle = true;
    }
}