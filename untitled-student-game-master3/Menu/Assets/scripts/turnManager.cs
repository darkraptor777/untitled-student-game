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
            if (Input.GetKey("a"))
            {
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
            if (Input.GetKey("b"))
            {
                playerTurn = true;
                enemyTurn = false;
            }
        }
        
    }
}
