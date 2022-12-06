using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public int startingPointIndex;
    public Transform[] points;

    private Vector2 positionBefore;
    private Vector2 positionAfter;
    private int i;
    void Start()
    {
        transform.position = points[startingPointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }

        positionBefore = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        positionAfter = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.position.y > transform.position.y)
        {
            collision.transform.SetParent(transform);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.position.y > transform.position.y)
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
