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
        if (gameObject.TryGetComponent(out IsLadder ladder))
        {

            ladder.LadderActive = !ladder.LadderActive;
            ladder.GetComponentInParent<BoxCollider2D>().enabled = ladder.LadderActive;
            ladder.pcEject();

        }
        else
        {
            colliderToSwap.isTrigger = !colliderToSwap.isTrigger;
        }
        
        
    }
}
