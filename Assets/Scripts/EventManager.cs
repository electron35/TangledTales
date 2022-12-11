using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // Event whenever we change world mode
    public delegate void FictionalMode(int currentRadius);
    public static event FictionalMode onModeSwitch;

    // Event sent whenever we change the radius of the fictional circle view
    public delegate void CircleRadius(int newRadius);
    public static event CircleRadius circleRadiusChanged;

    public bool currentFictionalMode;
    public int currentCircleRadius;

    public GameController gameController = null;
    public PlayerController playerController = null;

    void Start()
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        currentFictionalMode = gameController.fictionalMode;
        currentCircleRadius = playerController.circleRadius;
    }

    void Update()
    {
        // Checking for world mode change
        if (currentFictionalMode != gameController.fictionalMode)
        {
            if (onModeSwitch != null)
            {
                onModeSwitch(currentCircleRadius);
            }
            currentFictionalMode = gameController.fictionalMode;
        }

        // Checking for circle radius change
        if (currentCircleRadius != playerController.circleRadius)
        {
            if (circleRadiusChanged != null)
            {
                currentCircleRadius = playerController.circleRadius;
                circleRadiusChanged(currentCircleRadius);
            }
        }
    }
}
