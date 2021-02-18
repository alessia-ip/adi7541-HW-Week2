using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    //this keeps track of this instance of the game manager
    public static gamemanager instance;
    
    //public int playerChildren; (had this for a different mechanic. leaving it in, in case i re-add it

    public static int levelNum = 0;
    //this keeps track of the current level number

    //these are to reset the player if the player messes up
     static GameObject player;

     static playercontroller.pColor OrigCol;
     static Vector3 playerPos;
    
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        playerPos = player.transform.position;
        OrigCol = player.GetComponent<playercontroller>().playerColor;
        
        Debug.Log("test");
        
        //get the current scene index, so we can just increment the scene number from here on
        levelNum = SceneManager.GetActiveScene().buildIndex;
        
        //set this instance as the singleton, if null
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //the function to go to the next level, based on the scene index
    public static void nextLevel()
    {
        SceneManager.LoadScene(levelNum);
    }


    private void Update()
    {
        //r to reset
        if (Input.GetKeyDown(KeyCode.R))
        {
            //reset the player vars
            playercontroller.pInstance.gameObject.transform.position = playerPos;
            playercontroller.pInstance.playerColor = OrigCol;
            //this is just reloading the level
            nextLevel();
        }
    }

    //other singletons will help keep the player consistent for the resets
    private void OnDestroy()
    {
        player = GameObject.FindWithTag("Player");
        playerPos = player.transform.position;
        OrigCol = player.GetComponent<playercontroller>().playerColor;
    }
    
}
