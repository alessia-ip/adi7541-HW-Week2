using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelEnd : MonoBehaviour
{

    public playercontroller.pColor endCol;
    private MeshRenderer rend;
    
    private Color purple = new Color(170/255f, 0, 217/255f);
    private Color orange = new Color(237/255f, 95/255f, 0);
    private Color green = new Color(6/255f, 176/255f, 0);

    void Start()
    {
        rend = gameObject.GetComponent<MeshRenderer>();
    }

    private void Update()
    {

     switch (endCol)
        {
            case playercontroller.pColor.white:
                rend.material.SetColor("_Color", Color.white);
                break;
            case playercontroller.pColor.red:
                rend.material.SetColor("_Color", Color.red);
                break;
            case playercontroller.pColor.yellow:
                rend.material.SetColor("_Color", Color.yellow);
                break;
            case playercontroller.pColor.blue:
                rend.material.SetColor("_Color", Color.blue);
                break;
            case playercontroller.pColor.orange:
                rend.material.SetColor("_Color", orange);
                break;
            case playercontroller.pColor.purple:
                //rend.material.SetColor("_Color", purple);
                rend.material.color = purple;
                break;
            case playercontroller.pColor.green:
                rend.material.SetColor("_Color", green);
                break;
            case playercontroller.pColor.black:
                rend.material.SetColor("_Color", Color.black);
                break;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.GetComponent<playercontroller>().playerColor == endCol)
        {
            gamemanager.levelNum++;
            gamemanager.nextLevel();
        }
    }
}
