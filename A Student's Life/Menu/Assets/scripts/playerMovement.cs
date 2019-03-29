using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);


        if (moveHorizontal == 0 && moveVertical == 0)
        {
            rb2d.velocity = new Vector2(0.0f, 0.0f);
        }
        rb2d.AddForce(movement * speed);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "World_Frank")
        {
            SceneManager.LoadScene("battleScene_Frank");
        }
        if (col.gameObject.tag == "RBumper")
        {
            SceneManager.LoadScene("overWorld_02");
        }
        if (col.gameObject.tag == "Shop")
        {
            SceneManager.LoadScene("shopScene");
        }
    }
}
