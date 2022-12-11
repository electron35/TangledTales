using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Inverses the component enabled state given in the components list, whenever we change world
/// For example, if the SpriteRenderer is given to the list and is enabled,
/// when InverseComponentState is called, the SpriteRenderer will be disabled.
/// And if it was disabled, it will get enabled whenever InverseComponentState is called again
/// </summary>
public class ComponentStateInverser : MonoBehaviour
{
    public List<Behaviour> components = new List<Behaviour>();

    void OnEnable()
    {
        EventManager.onModeSwitch += InverseComponentState;
    }

    void OnDisable()
    {
        EventManager.onModeSwitch -= InverseComponentState;
    }

    void InverseComponentState(int currentCircleRadius)
    {
        foreach (Behaviour component in components)
        {
            component.enabled = !component.enabled;
        }
    }
}
