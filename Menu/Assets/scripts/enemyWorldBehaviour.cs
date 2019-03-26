using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyWorldBehaviour : MonoBehaviour
{
    public bool canMove;
    public bool moving;

    public int xDirection;
    public int yDirection;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove && !moving)
        {
            xDirection = (int)Random.Range(-1, 2);
            yDirection = (int)Random.Range(-1, 2);
            StartCoroutine(move());
        }
        if (moving)
        {
            transform.position = new Vector3(transform.position.x + (float)(xDirection / 100.0f), transform.position.y + (float)(yDirection/100.0f), 0.0f);
        }
    }

    IEnumerator move()
    {
        canMove = false;
        moving = true;
        yield return new WaitForSeconds(3.0f);
        canMove = true;
        moving = false;
    }
}
