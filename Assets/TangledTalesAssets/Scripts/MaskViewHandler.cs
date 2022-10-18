using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskViewHandler : MonoBehaviour
{
    public RectTransform rectTransform;
    public EventManager eventManager;
    public Canvas canvas;

    void OnEnable()
    {
        EventManager.onModeSwitch += ChangeSize;
    }

    void OnDisable()
    {
        EventManager.onModeSwitch -= ChangeSize;
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

    private void ChangeSize()
    {
        Debug.Log("In fictional Mode : " + eventManager.currentFictionalMode);
        //this.transform.localScale = new Vector3(0, 0, 0);
        rectTransform.sizeDelta = eventManager.currentFictionalMode ? new Vector2(400, 400) : new Vector2(0, 0);
    }
}
