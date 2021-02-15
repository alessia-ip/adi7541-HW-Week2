using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colourChange : MonoBehaviour
{
    public enum colChoice
    {
        red,
        yellow,
        blue
    };

    private playercontroller playerObj;
    
    public colChoice col = colChoice.red;
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            Debug.Log("HIT");
            playerObj = other.gameObject.GetComponent<playercontroller>();
            newCol();
        }
        
    }

    void newCol()
    {

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
        }

    }
    
}
