using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyWorldBehaviour : MonoBehaviour
{
	public GameObject saveObject;
    private SaveInfoScript saveInfo;
	private WorldSaveScript worldInfo;
	
	
    public bool canMove;
    public bool moving;
	public int ID;
    public int xDirection;
    public int yDirection;

    // Start is called before the first frame update
    void Start()
    {
		
		print(ID);
        canMove = true;
        moving = false;
		
		saveInfo=saveObject.GetComponent<SaveInfoScript>();
		worldInfo=saveObject.GetComponent<WorldSaveScript>();
		
		if(ID==1)
			gameObject.SetActive(worldInfo.enemyOne);
		
		if(ID==2)
			gameObject.SetActive(worldInfo.enemyTwo);
		
		if(ID==3)
			gameObject.SetActive(worldInfo.enemyThree);

		
		
    }
	/*
	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
		switch(ID)
		{
			case 1:
				gameObject.SetActive(worldInfo.enemyOne);
				break;
			case 2:
				gameObject.SetActive(worldInfo.enemyTwo);
				break;
			case 3:
				gameObject.SetActive(worldInfo.enemyThree);
				break;
		}
	}
	*/
	

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
