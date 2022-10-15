using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
        public delegate void FictionalMode();
        public static event FictionalMode onModeSwitch;

        private GameController gameController = null;
        private bool currentFictionalMode;

        void Start()
        {
                gameController = GameObject.Find("Game Controller").GetComponent<GameController>();

                currentFictionalMode = gameController.fictionalMode;
        }

        void Update()
        {
                if (currentFictionalMode != gameController.fictionalMode)
                {
                        if (onModeSwitch != null)
                        {
                                onModeSwitch();
                        }
                        currentFictionalMode = gameController.fictionalMode;
                }
        }
}
