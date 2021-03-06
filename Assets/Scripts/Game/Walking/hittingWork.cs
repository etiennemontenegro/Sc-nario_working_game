﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hittingWork : MonoBehaviour
{
    public SceneHandler changingScene;
    private GameObject work,player;
    private float moveSpeed = .05f;
    // Start is called before the first frame update
    void Start()
    {
        work = gameObject;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (work.transform.position.x > 9)
        {

            work.transform.Translate(-1 * moveSpeed, 0, 0);
         

        }
       
        else
        {
           playerHandler.isScrolling = false;
            player.transform.position = new Vector3(player.transform.position.x + .05f, player.transform.position.y, player.transform.position.z);
        }
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {      
            //------------------------------------------------------------------------------------------ SOUND ENTERING WORK
            GameObject.Find("PrefabGameLogic").GetComponent<Animator>().SetBool("PlayFade", true);
            StartCoroutine(FadeCoroutine());
        }   
    }

    IEnumerator FadeCoroutine()
    {
        yield return new WaitForSeconds(1);
        changingScene.scene1To2();
    }
}