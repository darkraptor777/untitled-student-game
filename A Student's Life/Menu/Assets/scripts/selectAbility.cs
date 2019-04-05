using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.scripts;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//text not updated when already present

public class selectAbility : MonoBehaviour
{
    public int selectedVar = 1;
    public bool toggle = true;

    public int selectedItem = 1;
    public bool canBrowse = false;
    public bool playerTurn = true;
    public bool enemyTurn = false;
    public bool defending = false;

    public GameObject attack;
    public GameObject defend;
    public GameObject items;
    public GameObject flee;
    public GameObject etext;
    public GameObject ptext;
    public GameObject failFlee;

    public GameObject itemMenu;

    public GameObject smallPotion;
    private GameObject smallPotionArrow;
    private GameObject smallPotionCount;

    public GameObject mediumPotion;
    private GameObject mediumPotionArrow;
    private GameObject mediumPotionCount;

    public GameObject largePotion;
    private GameObject largePotionArrow;
    private GameObject largePotionCount;

    public GameObject itemsBack;
    private GameObject itemsBackArrow;

    private enemyScript eScript;
    private playerScript pScript;

    private SaveInfoScript saveScript;

    private void Start()
    {
        eScript = GameObject.FindWithTag("Enemy").GetComponent<enemyScript>();
        pScript = GameObject.FindWithTag("Player").GetComponent<playerScript>();

        saveScript = pScript.saveObject.GetComponent<SaveInfoScript>();

        smallPotionArrow = smallPotion.transform.GetChild(0).gameObject;
        mediumPotionArrow = mediumPotion.transform.GetChild(0).gameObject;
        largePotionArrow = largePotion.transform.GetChild(0).gameObject;
        itemsBackArrow = itemsBack.transform.GetChild(0).gameObject;

        smallPotionCount = smallPotion.transform.GetChild(1).gameObject;
        mediumPotionCount = mediumPotion.transform.GetChild(1).gameObject;
        largePotionCount = largePotion.transform.GetChild(1).gameObject;

        
    }

    private void updatePotionCounts()
    {
        
        smallPotionCount.GetComponent<Text>().text = saveScript.SmallPotions.ToString();
        mediumPotionCount.GetComponent<Text>().text = saveScript.MediumPotions.ToString();
        largePotionCount.GetComponent<Text>().text = saveScript.LargePotions.ToString();
        
    }

    public void Update()
    {
        if (playerTurn == true)
        {
            defending = false;
            if (toggle == true)
            {
                Toggling();
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
                    //pScript.addhealth(1);
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

            if (Input.GetKeyDown("space") && selectedVar == 1) //attack option
            {
                //ptext.SetActive(true);
                eScript.takedamage(pScript.totalDamage);
                pScript.updateDMGText(pScript.totalDamage);
                StartCoroutine(WaitForPText());
                //ptext.SetActive(false);
                playerTurn = false;
                enemyTurn = true;
            }
            if (Input.GetKeyDown("space") && selectedVar == 2) //defend option
            {
                //etext.SetActive(true);
                //GameObject.FindWithTag("Player").GetComponent<playerScript>().PlayerDamageCalcDef();
                defending = true;
                StartCoroutine(WaitForEText());
                //etext.SetActive(false);
                playerTurn = false;
                enemyTurn = true;
            }
            if (Input.GetKeyDown("space") && selectedVar == 3 && !canBrowse) //items menu
            {
                items.SetActive(false);
                print("Player Opens Menu");
                itemMenu.SetActive(true);
                toggle = false;
                canBrowse = true;
                StartCoroutine(MenuSwitchDelay());
            }
            if (Input.GetKeyDown("space") && selectedVar == 4) //flee option
            {
				if(Random.value > 0.5)
				{
					SceneManager.LoadScene("overWorld_01");//needs changing to current overworld
                }
                else if (Random.value < 0.5)
                {
                    StartCoroutine(WaitForFleeText());
                }
            }

            if (canBrowse)
            {
                updatePotionCounts();
                ItemBrowse();
                if (selectedItem == 1)
                {
                    smallPotionArrow.SetActive(true);
                    mediumPotionArrow.SetActive(false);
                    largePotionArrow.SetActive(false);
                    itemsBackArrow.SetActive(false);
                }
                if (selectedItem == 2)
                {
                    smallPotionArrow.SetActive(false);
                    mediumPotionArrow.SetActive(true);
                    largePotionArrow.SetActive(false);
                    itemsBackArrow.SetActive(false);
                }
                if (selectedItem == 3)
                {
                    smallPotionArrow.SetActive(false);
                    mediumPotionArrow.SetActive(false);
                    largePotionArrow.SetActive(true);
                    itemsBackArrow.SetActive(false);
                }
                if (selectedItem == 4)
                {
                    smallPotionArrow.SetActive(false);
                    mediumPotionArrow.SetActive(false);
                    largePotionArrow.SetActive(false);
                    itemsBackArrow.SetActive(true);
                }

                if (Input.GetKeyDown("space") && selectedItem == 1 && saveScript.SmallPotions >0) //use small potion
                {
                    pScript.addhealth(20);
                    saveScript.SmallPotions -= 1;
                    updatePotionCounts();
                    canBrowse = false;
                    toggle = true;
                    itemMenu.SetActive(false);
                    playerTurn = false;
                    enemyTurn = true;
                }
                if (Input.GetKeyDown("space") && selectedItem == 2 && saveScript.MediumPotions > 0) //use medium potion
                {
                    pScript.addhealth(40);
                    saveScript.MediumPotions -= 1;
                    updatePotionCounts();
                    canBrowse = false;
                    toggle = true;
                    itemMenu.SetActive(false);
                    playerTurn = false;
                    enemyTurn = true;
                }
                if (Input.GetKeyDown("space") && selectedItem == 3 && saveScript.LargePotions > 0) //use large potion
                {
                    pScript.addhealth(80);
                    saveScript.LargePotions -= 1;
                    updatePotionCounts();
                    canBrowse = false;
                    toggle = true;
                    itemMenu.SetActive(false);
                    playerTurn = false;
                    enemyTurn = true;
                }
                if (Input.GetKeyDown("space") && selectedItem == 4) //return
                {
                    itemMenu.SetActive(false);
                    canBrowse = false;
                    toggle = true;
                }
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


    void Toggling()
    {
        //print(Input.GetAxis("Horizontal"));
        if (Input.GetAxis("Horizontal") < 0)
        {
            selectedVar--;
            StartCoroutine(ToggleTimer());
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            selectedVar++;
            StartCoroutine(ToggleTimer());
        }
        if (selectedVar > 4)
            selectedVar = 1;
        if (selectedVar < 1)
            selectedVar = 4;
    }

    IEnumerator ToggleTimer()
    {
        toggle = false;
        yield return new WaitForSeconds(0.2f);
        toggle = true;
    }

    IEnumerator MenuSwitchDelay()
    {
        toggle = false;
        canBrowse = false;
        yield return new WaitForSeconds(0.2f);
        canBrowse = true;
    }

    void ItemBrowse()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            selectedItem--;
            StartCoroutine(BrowseTimer());
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            selectedItem++;
            StartCoroutine(BrowseTimer());
        }
        if (selectedItem > 4)
            selectedItem = 1;
        if (selectedItem < 1)
            selectedItem = 4;  
    }

    IEnumerator BrowseTimer()
    {
        canBrowse = false;
        yield return new WaitForSeconds(0.2f);
        canBrowse = true;
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
    IEnumerator WaitForFleeText()
    {
        failFlee.SetActive(true);
        yield return new WaitForSeconds(2f);
        failFlee.SetActive(false);
    }
}