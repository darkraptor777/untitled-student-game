using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public int playerHealth = 100;
    public int bronzeSwordDamage = 15;
    public int playerDamage = 10;

    bool bronzeSwordUp = false;

    void Start()
    {
        
    }

    void Update()
    {
        if(bronzeSwordUp == true)
        {
            int totalDamage = playerDamage + bronzeSwordDamage;
        }
    }
}