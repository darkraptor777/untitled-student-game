using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
	
	public GameObject saveObject;
    private SaveInfoScript saveInfo;
	private WorldSaveScript worldInfo;
	
    public float speed;
    private Rigidbody2D rb2d;
    public string nextLVL;
    private bool facingRight;

    void lastWorld()
    {
        if (!Directory.Exists("Save Info"))
            Directory.CreateDirectory("Save Info");
        FileStream file = File.Create("Save Info/LastWorld.txt");
        file.Close();
        File.WriteAllText("Save Info/LastWorld.txt", SceneManager.GetActiveScene().name);
    }

    void Start()
    {
		print("Loaded Player");
		saveInfo=saveObject.GetComponent<SaveInfoScript>();
		worldInfo=saveObject.GetComponent<WorldSaveScript>();
		transform.position= new Vector3(worldInfo.playerX,worldInfo.playerY, 0.0f);
        rb2d = transform.gameObject.GetComponent<Rigidbody2D>();
    }
	

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
		//FlipImg(moveHorizontal);
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        if (moveHorizontal == 0 && moveVertical == 0)
        {
            rb2d.velocity = new Vector2(0.0f, 0.0f);
        }
        rb2d.AddForce(movement * speed);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
		worldInfo.playerX=transform.position.x;
		worldInfo.playerY=transform.position.y;
		worldInfo.Save();
        if (col.gameObject.name == "World_Frank")
        {
			switch(col.gameObject.GetComponent<enemyWorldBehaviour>().ID)
			{
				case 1:
					worldInfo.enemyOne=false;
					break;
				case 2:
					worldInfo.enemyTwo=false;
					break;
				case 3:
					worldInfo.enemyThree=false;
					break;
			}
			worldInfo.Save();
            SceneManager.LoadScene("battleScene_Frank");
        }
        if (col.gameObject.name == "World_Maw")
        {
            switch (col.gameObject.GetComponent<enemyWorldBehaviour>().ID)
            {
                case 1:
                    worldInfo.enemyOne = false;
                    break;
                case 2:
                    worldInfo.enemyTwo = false;
                    break;
                case 3:
                    worldInfo.enemyThree = false;
                    break;
            }
            worldInfo.Save();
            SceneManager.LoadScene("battleScene_Maw");
        }
        if (col.gameObject.tag == "RBumper")
        {

            worldInfo.SaveDEFAULT(nextLVL + ".txt");
            SceneManager.LoadScene(nextLVL);
        }
        if (col.gameObject.tag == "Shop")
        {
            lastWorld();
            SceneManager.LoadScene("shopScene");
        }
    }

    private void FlipImg(float moveHorizontal)
    {
        if (moveHorizontal < 0 && !facingRight || moveHorizontal > 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}