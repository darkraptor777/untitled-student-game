using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timerNewScene : MonoBehaviour
{
    float timer = 8f;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            SceneManager.LoadScene("overWorld_01");
        }
    }
}