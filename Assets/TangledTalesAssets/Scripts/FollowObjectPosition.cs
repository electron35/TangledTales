using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjectPosition : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, -20, 0);
    public GameObject objectToFollow;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = objectToFollow.transform.position + offset;
    }
}
