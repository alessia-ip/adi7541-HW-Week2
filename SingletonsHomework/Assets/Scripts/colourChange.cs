using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colourChange : MonoBehaviour
{

    //an enum to define potential colour  options that a capsule can be that the layer can use
    public enum colChoice
    {
        red,
        yellow,
        blue
    };

    //the player controller
    private playercontroller playerObj;
    
    //the default choice is red, but this is just the colour enum selector
    public colChoice col = colChoice.red;
    
    private void OnTriggerEnter(Collider other)
    {
    
        //when the player enters the trigger, execute the 'newCol' function
        if (other.tag == "Player")
        {
            Debug.Log("HIT");
            playerObj = other.gameObject.GetComponent<playercontroller>();
            newCol();
        }
        
    }

    
    void newCol()
    {
        //switch statement to change the player's colour based on the current col and the capsule colour
        switch (col)
        {
            case colChoice.red:
                if (playerObj.playerColor == playercontroller.pColor.black)
                {
                    playerObj.playerColor = playercontroller.pColor.red;
                }
                else if (playerObj.playerColor == playercontroller.pColor.blue)
                {
                    playerObj.playerColor = playercontroller.pColor.purple;
                }
                else if (playerObj.playerColor == playercontroller.pColor.yellow)
                {
                    playerObj.playerColor = playercontroller.pColor.orange;
                } else if (playerObj.playerColor == playercontroller.pColor.green)
                {
                    playerObj.playerColor = playercontroller.pColor.white;
                }
                break;
            case colChoice.blue:
                if (playerObj.playerColor == playercontroller.pColor.black)
                {
                    playerObj.playerColor = playercontroller.pColor.blue;
                }
                else if (playerObj.playerColor == playercontroller.pColor.red)
                {
                    playerObj.playerColor = playercontroller.pColor.purple;
                }
                else if (playerObj.playerColor == playercontroller.pColor.yellow)
                {
                    playerObj.playerColor = playercontroller.pColor.green;
                } else if (playerObj.playerColor == playercontroller.pColor.orange)
                {
                    playerObj.playerColor = playercontroller.pColor.white;
                }
                break;
            case colChoice.yellow:
                if (playerObj.playerColor == playercontroller.pColor.black)
                {
                    playerObj.playerColor = playercontroller.pColor.yellow;
                }
                else if (playerObj.playerColor == playercontroller.pColor.red)
                {
                    playerObj.playerColor = playercontroller.pColor.orange;
                }
                else if (playerObj.playerColor == playercontroller.pColor.blue)
                {
                    playerObj.playerColor = playercontroller.pColor.green;
                } else if (playerObj.playerColor == playercontroller.pColor.purple)
                {
                    playerObj.playerColor = playercontroller.pColor.white;
                }
                break;
        }

    }
    
}
