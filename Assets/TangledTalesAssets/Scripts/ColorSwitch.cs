using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitch : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public bool colorSwitched = false;

    void OnEnable()
    {
        EventManager.onModeSwitch += SwitchColor;
    }

    void OnDisable()
    {
        EventManager.onModeSwitch -= SwitchColor;
    }
    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void SwitchColor()
    {
        colorSwitched = !colorSwitched;

        spriteRenderer.color = colorSwitched ? Color.blue : Color.white;
    }
}
