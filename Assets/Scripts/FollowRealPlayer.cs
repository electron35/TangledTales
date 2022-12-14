using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRealPlayer : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, -40, 0);
    public GameObject realPlayer;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        this.transform.position = realPlayer.transform.position + offset;

        // Copy sprite properties from the real player
        spriteRenderer.sprite = realPlayer.GetComponent<SpriteRenderer>().sprite;
        spriteRenderer.flipX = realPlayer.GetComponent<SpriteRenderer>().flipX;
    }
}
