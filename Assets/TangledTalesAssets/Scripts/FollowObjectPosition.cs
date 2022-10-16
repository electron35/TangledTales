using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjectPosition : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, -20, 0);
    public GameObject followObject;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = followObject.transform.position + offset;
    }
}
