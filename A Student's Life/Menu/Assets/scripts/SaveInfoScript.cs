using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveInfoScript : MonoBehaviour
{
    public int Health;
    public int Money;
    public int SmallPotions;
    public int MediumPotions;
    public int LargePotions;
    public int WeaponTier;
    public int BootTier;
    public int ArmourTier;

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    public void Save()
    {
        //write some info to a text file
        string Info = Health + " " + Money + " " + SmallPotions + " " + MediumPotions + " "+ LargePotions + " " + WeaponTier + " " + BootTier + " " + ArmourTier + " ";

        if (!Directory.Exists("Save Info"))
            Directory.CreateDirectory("Save Info");
        FileStream file = File.Create("Save Info/Save.txt");
        file.Close();
        File.WriteAllText("Save Info/Save.txt", Info);
    }

    public void Load()
    {
        string Info;
        try
        {
            Info = File.ReadAllText("Save Info/Save.txt");
        }
        catch 
        {
            Save();
            Info = File.ReadAllText("Save Info/Save.txt");
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
                    Health = Convert.ToInt32(CurrentInfo);
                }
                else if (SpaceCount == 1)
                {
                    Money = Convert.ToInt32(CurrentInfo);
                }
                else if (SpaceCount == 2)
                {
                    SmallPotions = Convert.ToInt32(CurrentInfo);
                }
                else if (SpaceCount == 3)
                {
                    MediumPotions = Convert.ToInt32(CurrentInfo);
                }
                else if (SpaceCount == 4)
                {
                    LargePotions = Convert.ToInt32(CurrentInfo);
                }
                else if (SpaceCount == 5)
                {
                    WeaponTier = Convert.ToInt32(CurrentInfo);
                }
                else if (SpaceCount == 6)
                {
                    BootTier = Convert.ToInt32(CurrentInfo);
                }
                else if (SpaceCount == 7)
                {
                    ArmourTier = Convert.ToInt32(CurrentInfo);
                }

                SpaceCount += 1;
                CurrentInfo = "";
            }
        }
    }

}
