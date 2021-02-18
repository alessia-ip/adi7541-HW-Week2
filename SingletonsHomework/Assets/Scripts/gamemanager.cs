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
    
    void Awake()
    {
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
    
}
