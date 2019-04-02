using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts;
using UnityEngine.SceneManagement;

//text not updated when already present

public class selectAbility : MonoBehaviour
{
    int selectedVar = 1;
    bool toggle = true;

    bool playerTurn = true;
    bool enemyTurn = false;

    bool defending = false;

    public GameObject attack;
    public GameObject defend;
    public GameObject items;
    public GameObject flee;
    public GameObject etext;
    public GameObject ptext;

    public GameObject itemMenu;

    private enemyScript eScript;
    private playerScript pScript;

    private void Start()
    {
        eScript = GameObject.FindWithTag("Enemy").GetComponent<enemyScript>();
        pScript = GameObject.FindWithTag("Player").GetComponent<playerScript>();
      
    }

    public void Update()
    {
        if (playerTurn == true)
        {
            defending = false;
            if (toggle == true)
            {
                StartCoroutine(Toggling());
                if (selectedVar == 1)
                {
                    attack.SetActive(true);
                    defend.SetActive(false);
                    items.SetActive(false);
                    flee.SetActive(false);
                    itemMenu.SetActive(false);
                }
                if (selectedVar == 2)
                {
                    attack.SetActive(false);
                    defend.SetActive(true);
                    items.SetActive(false);
                    flee.SetActive(false);
                    itemMenu.SetActive(false);
                }
                if (selectedVar == 3)
                {
                    attack.SetActive(false);
                    defend.SetActive(false);
                    items.SetActive(true);
                    flee.SetActive(false);
                    itemMenu.SetActive(true);
                    pScript.addhealth(1);
                }
                if (selectedVar == 4)
                {
                    attack.SetActive(false);
                    defend.SetActive(false);
                    items.SetActive(false);
                    flee.SetActive(true);
                    itemMenu.SetActive(false);
                }
            }
            if (Input.GetKeyDown("space") && selectedVar == 1)
            {
                //ptext.SetActive(true);
                eScript.takedamage(pScript.totalDamage);
                pScript.updateDMGText(pScript.totalDamage);
                StartCoroutine(WaitForPText());
                //ptext.SetActive(false);
                playerTurn = false;
                enemyTurn = true;
            }
            if (Input.GetKeyDown("space") && selectedVar == 2)
            {
                //etext.SetActive(true);
                //GameObject.FindWithTag("Player").GetComponent<playerScript>().PlayerDamageCalcDef();
                defending = true;
                StartCoroutine(WaitForEText());
                //etext.SetActive(false);
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
                SceneManager.LoadScene("overWorld_01");
            }
        }

        //enemy turn/ai script
        if(enemyTurn==true && playerTurn == false)
        {
            attack.SetActive(false);
            defend.SetActive(false);
            items.SetActive(false);
            flee.SetActive(false);
            //play animation



            if (!defending)
            {
                print("NO");
                eScript.updateDMGText(eScript.enemyDamage);
                pScript.takedamage(eScript.enemyDamage);
            }
            if (defending)
            {
                print("YES");
                eScript.updateDMGText(eScript.enemyDamage / 2);
                pScript.takedamage(eScript.enemyDamage / 2);
            }
            StartCoroutine(WaitForEText());
            
            playerTurn = true;
            enemyTurn = false;
        }
    }


    IEnumerator Toggling()
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
    IEnumerator WaitForEText()
    {
        etext.SetActive(true);
        yield return new WaitForSeconds(2f);
        etext.SetActive(false);
    }
    IEnumerator WaitForPText()
    {
        ptext.SetActive(true);
        yield return new WaitForSeconds(2f);
        ptext.SetActive(false);
    }
}