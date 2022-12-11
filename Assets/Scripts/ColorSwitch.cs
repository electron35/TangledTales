using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitch : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private new BoxCollider2D collider;
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
        collider = GetComponent<BoxCollider2D>();
    }

    void SwitchColor(int currentCircleRadius)
    {
        colorSwitched = !colorSwitched;
        collider.enabled = !colorSwitched;
        

        // spriteRenderer.color = colorSwitched ? Color.blue : Color.white;
        spriteRenderer.enabled = !colorSwitched;
    }
}
