using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
        public delegate void FictionalMode();
        public static event FictionalMode onModeSwitch;

        public bool currentFictionalMode;

        private GameController gameController = null;

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
