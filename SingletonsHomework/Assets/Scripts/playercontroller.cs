using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class playercontroller : MonoBehaviour
{
    //the instance manager
    public static playercontroller pInstance;
    
    //movement vectors
    private Vector2 screenPos;
    private Vector2 worldPos;
    private Vector3 newPos;

    //these are colours that needed to be pre-defined
    private Color purple = new Color(170/255f, 0, 217/255f);
    private Color orange = new Color(237/255f, 95/255f, 0);
    private Color green = new Color(6/255f, 176/255f, 0);

    //possible colours that the player object can be
    public enum pColor {white, red, blue, yellow, purple, orange, green, black};

    //a var to hold the player's current colour. The default is black
    public pColor playerColor = pColor.black;
    
    //the camera
    public Camera cam;

    //a mesh renderer for the player's mesh 
    private MeshRenderer rend;
    
    void Awake()
    {
        //on awake, if instance is null, this gameobject becomes the instance
        //do not destroy on load, but destroy all other objects that are not the current instance
        if (pInstance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            pInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //get the mesh renderer on start
        rend = this.gameObject.GetComponent<MeshRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        //this is the mouse position on the screen
        //then we translate it to the worldposition
        //then use that to set a new vector for the player to move towards
        screenPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        worldPos = cam.ScreenToWorldPoint(screenPos);
        newPos = new Vector3(worldPos.x, worldPos.y, gameObject.transform.position.z);
        
        //lerp the player character towards the new position in worldspace where the mouse is
        this.transform.position = Vector3.Lerp(
            this.transform.position,
            newPos,
            Time.deltaTime);

        //when the player colour var changes, this switch statement is used
        //this changes the mesh's render colour
        //it also changes what layer the player is on in the scene
        //in the physics settings, same colours are set not to collide
        //example: layer 6 is the white layer. The white player object will not collide with walls on that layer
        switch (playerColor)
        {
            case pColor.white:
                rend.material.SetColor("_Color", Color.white);
                gameObject.layer = 6;
                break;
            case pColor.red:
                rend.material.SetColor("_Color", Color.red);
                gameObject.layer = 7;
                break;
            case pColor.yellow:
                rend.material.SetColor("_Color", Color.yellow);
                gameObject.layer = 8;
                break;
            case pColor.blue:
                rend.material.SetColor("_Color", Color.blue);
                gameObject.layer = 9;
                break;
            case pColor.orange:
                rend.material.SetColor("_Color", orange);
                gameObject.layer = 11;
                break;
            case pColor.purple:
                rend.material.SetColor("_Color", purple);
                gameObject.layer = 12;
                break;
            case pColor.green:
                rend.material.SetColor("_Color", green);
                gameObject.layer = 10;
                break;
            case pColor.black:
                rend.material.SetColor("_Color", Color.black);
                gameObject.layer = 13;
                break;
        }
        
        
    }
    
}
