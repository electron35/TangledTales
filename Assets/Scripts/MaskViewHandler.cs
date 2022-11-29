using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskViewHandler : MonoBehaviour
{
    public RectTransform rectTransform;
    public EventManager eventManager;
    public Canvas canvas;

    private int circleRadius = 750;

    void OnEnable()
    {
        EventManager.onModeSwitch += SwitchMode;
        EventManager.circleRadiusChanged += ChangeRadius;
    }

    void OnDisable()
    {
        EventManager.onModeSwitch -= SwitchMode;
        EventManager.circleRadiusChanged -= ChangeRadius;
    }

    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        eventManager = FindObjectOfType<EventManager>();
    }

    private void Update()
    {
    }

    private void SwitchMode()
    {
        rectTransform.sizeDelta = eventManager.currentFictionalMode ? new Vector2(0, 0) : new Vector2(circleRadius, circleRadius);
    }

    private void ChangeRadius(int newRadius)
    {
        circleRadius = newRadius;
        rectTransform.sizeDelta = new Vector2(circleRadius, circleRadius);
    }
}
