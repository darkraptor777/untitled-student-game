using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnManager : MonoBehaviour
{
    bool playerTurn = true;
    bool enemyTurn = false;
    
    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTurn == true)
        {
            print("player turn");
            if (Input.GetKey("a"))
            {
                print("a pressed");
                playerTurn = false;
                enemyTurn = true;
            }
            //if (Input.GetKey("space"))
            //{
            //    print("player attacks");

            //}
        }
        if (enemyTurn == true)
        {
            print("enemy turn");
            if (Input.GetKey("b"))
            {
                print("a pressed");
                playerTurn = true;
                enemyTurn = false;
            }
        }
        
    }
}
