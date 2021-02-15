using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public static gamemanager instance;
    
    //public int playerChildren;

    public static int levelNum = 0;
    
    void Awake()
    {
        levelNum = SceneManager.GetActiveScene().buildIndex;
        
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

    public static void nextLevel()
    {
        SceneManager.LoadScene(levelNum);
    }
    
}
