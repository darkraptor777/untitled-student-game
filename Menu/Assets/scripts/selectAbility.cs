using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts;

public class selectAbility : MonoBehaviour
{
    int selectedVar = 1;
    bool toggle = true;

    bool playerTurn = true;
    bool enemyTurn = false;

    public GameObject attack;
    public GameObject defend;
    public GameObject items;
    public GameObject flee;

    public void Update()
    {
        //player turn
        print("player turn");
        if (playerTurn == true)
        {
            if (toggle == true)
            {
                StartCoroutine(toggling());
                if (selectedVar == 1)
                {
                    attack.SetActive(true);
                    defend.SetActive(false);
                    items.SetActive(false);
                    flee.SetActive(false);
                }
                if (selectedVar == 2)
                {
                    attack.SetActive(false);
                    defend.SetActive(true);
                    items.SetActive(false);
                    flee.SetActive(false);
                }
                if (selectedVar == 3)
                {
                    attack.SetActive(false);
                    defend.SetActive(false);
                    items.SetActive(true);
                    flee.SetActive(false);
                }
                if (selectedVar == 4)
                {
                    attack.SetActive(false);
                    defend.SetActive(false);
                    items.SetActive(false);
                    flee.SetActive(true);
                }
            }
            if (Input.GetKeyDown("space") && selectedVar == 1)
            {
                print("Player Attacks");
                GameObject.FindWithTag("Enemy").GetComponent<enemyScript>().EnemyDamageCalc();
                playerTurn = false;
                enemyTurn = true;
            }
            if (Input.GetKeyDown("space") && selectedVar == 2)
            {
                print("Player Defends");
                //defend bonus true, damage calc redone
                playerTurn = false;
                enemyTurn = true;
            }
            if (Input.GetKeyDown("space") && selectedVar == 3)
            {
                print("Player Opens Menu");
                //unhides menu - bool inmenu true (example)
                playerTurn = false;
                enemyTurn = true;
            }
            if (Input.GetKeyDown("space") && selectedVar == 4)
            {
                print("Player Flees");
                //quit battle
            }
        }


        if(enemyTurn==true && playerTurn == false)
        {
            print("enemy turn");
            attack.SetActive(false);
            defend.SetActive(false);
            items.SetActive(false);
            flee.SetActive(false);
            //play animation
            GameObject.FindWithTag("Player").GetComponent<playerScript>().PlayerDamageCalc();
            //wait
            playerTurn = true;
            enemyTurn = false;
        }
    }


    IEnumerator toggling()
    {
        toggle = false;
        if (Input.GetAxis("Horizontal") < 0)
        {
            selectedVar--;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            selectedVar++;
        }
        if (selectedVar > 4)
            selectedVar = 1;
        if (selectedVar < 1)
            selectedVar = 4;

            yield return new WaitForSeconds(0.3f);
            toggle = true;
        }
}