using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backtoblack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //this sets the player colour back to black
        if (other.tag == "Player")
        {
            other.GetComponent<playercontroller>().playerColor = playercontroller.pColor.black;
        }
    }
}
