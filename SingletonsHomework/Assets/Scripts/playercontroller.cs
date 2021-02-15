using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class playercontroller : MonoBehaviour
{
    public static playercontroller pInstance;
    private Vector2 screenPos;
    private Vector2 worldPos;
    private Vector3 newPos;

    private Color purple = new Color(194, 0, 174);
    private Color orange = new Color(237, 95, 0);
    private Color green = new Color(6, 176, 0);

    public enum pColor {white, red, blue, yellow, purple, orange, green, black};

    public pColor playerColor = pColor.black;
    
    public Camera cam;

    private MeshRenderer rend;
    
    void Awake()
    {
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
        rend = this.gameObject.GetComponent<MeshRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        screenPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        worldPos = cam.ScreenToWorldPoint(screenPos);
        newPos = new Vector3(worldPos.x, worldPos.y, gameObject.transform.position.z);
        
        this.transform.position = Vector3.Lerp(
            this.transform.position,
            newPos,
            Time.deltaTime);

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
