using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScreenPosition : MonoBehaviour
{
    public GameObject objectToFollow;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 objectScreenPos = cam.WorldToScreenPoint(objectToFollow.transform.position);
        this.transform.position = objectScreenPos;
    }
}
