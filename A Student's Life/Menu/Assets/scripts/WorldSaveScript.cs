using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldSaveScript : MonoBehaviour
{
	public GameObject player;
	public string filePath;
    public float playerX;
	public float playerY;
	public bool enemyOne;
	public bool enemyTwo;
	public bool enemyThree;

    // Start is called before the first frame update
    void Start()
    {
		print("Loaded World Save");
        Load();
    }

    public void Save()
    {
        //write some info to a text file
        string Info = player.transform.position.x + " " + player.transform.position.y + " " + enemyOne + " " + enemyTwo + " "+ enemyThree + " ";

        if (!Directory.Exists("Save Info"))
            Directory.CreateDirectory("Save Info");
        FileStream file = File.Create("Save Info/"+filePath);
        file.Close();
        File.WriteAllText("Save Info/"+filePath, Info);
    }

    public void Load()
    {
        string Info;
        try
        {
            Info = File.ReadAllText("Save Info/"+filePath);
        }
        catch 
        {
            Save();
            Info = File.ReadAllText("Save Info/"+filePath);
        }
        int SpaceCount = 0;
        string CurrentInfo = "";
        for (int x = 0; x < Info.Length; x++)
        {

            if (Info[x].ToString() != " ")
                CurrentInfo += Info[x].ToString();
            else
            {
                if (SpaceCount == 0)
                {
                    playerX = float.Parse(CurrentInfo);
                }
                else if (SpaceCount == 1)
                {
                    playerY = float.Parse(CurrentInfo);
                }
                else if (SpaceCount == 2)
                {
                    enemyOne = Convert.ToBoolean(CurrentInfo);
                }
                else if (SpaceCount == 3)
                {
                    enemyTwo = Convert.ToBoolean(CurrentInfo);
                }
                else if (SpaceCount == 4)
                {
                    enemyThree = Convert.ToBoolean(CurrentInfo);
                }

                SpaceCount += 1;
                CurrentInfo = "";
            }
        }
    }

}
