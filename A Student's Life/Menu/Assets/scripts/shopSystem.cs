using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopSystem : MonoBehaviour
{
    //player gold amount
    int playerGold = 20000;

    //weapon prices
    int bronzeSwordCost = 100;
    bool bronzeSwordUp = false;
    int ironSwordCost = 200;
    bool ironSwordUp = false;
    int steelSwordCost = 500;
    bool steelSwordUp = false;
    int rsteelSwordCost = 1000;
    bool rsteelSwordUp = false;

    //armour prices
    int bronzeArmourCost = 100;
    bool bronzeArmourUp = false;
    int ironArmourCost = 200;
    bool ironArmourUp = false;
    int steelArmourCost = 500;
    bool steelArmourUp = false;
    int rsteelArmourCost = 1000;
    bool rsteelArmourUp = false;

    //boots prices
    int boots1Cost = 50;
    bool boots1Up = false;
    int boots2Cost = 100;
    bool boots2Up = false;
    int boots3Cost = 150;
    bool boots3Up = false;
    int boots4Cost = 250;
    bool boots4Up = false;

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
    public Text playerMoney;

    void Start()
    {

    }

    void Update()
    {
        smallpotionAmount.text = "" + potSAmount;
        mediumpotionAmount.text = "" + potMAmount;
        largepotionAmount.text = "" + potLAmount;
        playerMoney.text = "" + playerGold;

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (playerGold >= potSCost)
            {
                playerGold = playerGold - potSCost;
                potSAmount++;
            }
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (playerGold >= potMCost)
            {
                playerGold = playerGold - potMCost;
                potMAmount++;
            }
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            if (playerGold >= potLCost)
            {
                playerGold = playerGold - potLCost;
                potLAmount++;
            }
        }
    }

    void Buy()
    {
        //weapon buying bools
        if (playerGold >= bronzeSwordCost)
        {
            bronzeSwordUp = true;
        }
        if (playerGold >= ironSwordCost)
        {
            ironSwordUp = true;
        }
        if (playerGold >= steelSwordCost)
        {
            steelSwordUp = true;
        }
        if (playerGold >= rsteelSwordCost)
        {
            rsteelSwordUp = true;
        }

        //armour buying bools
        if (playerGold >= bronzeArmourCost)
        {
            bronzeArmourUp = true;
        }
        if (playerGold >= ironArmourCost)
        {
            ironArmourUp = true;
        }
        if (playerGold >= steelArmourCost)
        {
            steelArmourUp = true;
        }
        if (playerGold >= rsteelArmourCost)
        {
            rsteelArmourUp = true;
        }

        //boots buying bools
        if (playerGold >= boots1Cost)
        {
            boots1Up = true;
        }
        if (playerGold >= boots2Cost)
        {
            boots2Up = true;
        }
        if (playerGold >= boots3Cost)
        {
            boots3Up = true;
        }
        if (playerGold >= boots4Cost)
        {
            boots4Up = true;
        }

        //potion buying stacks
    }
}