using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bossScript : MonoBehaviour
{
    public GameObject musicObjectOne;
    public GameObject musicObjectTwo;
    private enemyScript escript;
    private Animator enemyAnim;

    private bool switchedStage=false;

    private AudioSource stageOne;
    private AudioSource stageTwo;

    void Start()
    {
        stageOne = musicObjectOne.GetComponent<AudioSource>();
        stageTwo = musicObjectTwo.GetComponent<AudioSource>();
        escript = gameObject.GetComponent<enemyScript>();
        enemyAnim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if(!switchedStage && escript.enemyHealth<=(escript.maxenemyHealth)/2)
        {
            stageOne.Stop();
            stageTwo.Play();
            enemyAnim.SetTrigger("Stage Two");
            switchedStage = true;
        }

      
    }

    
}
