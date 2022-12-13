using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LampInteraction : MonoBehaviour
{

    public bool on = false;
    public Sprite lampOnSprite;
    public Sprite lampOffSprite;

    private Light2D lampLight = null;
    private SpriteRenderer lampSprite = null;

    void Start()
    {
        lampLight = GetComponentInChildren<Light2D>();
        lampSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (on)
        {
            TurnLightOn();
        }
        else
        {
            TurnLightOff();
        }
    }

    public void TurnLightOn()
    {
        lampLight.enabled = true;
        lampSprite.sprite = lampOnSprite;
    }
    
    public void TurnLightOff()
    {
        lampLight.enabled = false;
        lampSprite.sprite = lampOffSprite;
    }
}
