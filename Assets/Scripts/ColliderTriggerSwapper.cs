using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTriggerSwapper : MonoBehaviour
{
    public Collider2D colliderToSwap;
    void OnEnable()
    {
        EventManager.onModeSwitch += InverseTriggerState;
    }

    void OnDisable()
    {
        EventManager.onModeSwitch -= InverseTriggerState;
    }

    void InverseTriggerState()
    {
        colliderToSwap.isTrigger = !colliderToSwap.isTrigger;
    }
}
