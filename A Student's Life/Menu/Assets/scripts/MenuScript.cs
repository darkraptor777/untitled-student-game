using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    int currVar = 1;
    bool toggle = true;

    public GameObject start;
    public GameObject options;
    public GameObject end;

    public void FixedUpdate()
    {
        if (toggle == true)
            {
                StartCoroutine(Toggling());
                if (currVar == 1)
                {
                    start.SetActive(true);
                    options.SetActive(false);
                    end.SetActive(false);
                }
                if (currVar == 2)
                {
                    start.SetActive(false);
                    options.SetActive(true);
                    end.SetActive(false);
                }
                if (currVar == 3)
                {
                    start.SetActive(false);
                    options.SetActive(false);
                    end.SetActive(true);
                }
            }
            if (Input.GetKeyDown("space") && currVar == 1)
            {
                SceneManager.LoadScene("overWorld_01");
            }
            if (Input.GetKeyDown("space") && currVar == 2)
            {
                SceneManager.LoadScene("optionsMenu");
            }
            if (Input.GetKeyDown("space") && currVar == 3)
            {
                Application.Quit();
            }
    }

IEnumerator Toggling()
    {
        toggle = false;
        if (Input.GetAxis("Vertical") > 0)
        {
            currVar--;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            currVar++;
        }
        if (currVar > 3)
            currVar = 1;
        if (currVar < 1)
            currVar = 3;

        yield return new WaitForSeconds(0.3f);
        toggle = true;
    }
}
	