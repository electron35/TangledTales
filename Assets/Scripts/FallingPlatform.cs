using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : PhysicsObject
{
    [Range(0.1f, 10)]
    public float TimeBeforeFall = 5.0f;
    [Range(0.1f, 10)]
    public float DestroyTime = 0.5f;

    public GameObject Spawner = null;
    
    private bool isFalling = false;

    public bool isFictionnal = false;

    private float platformHeight;
    // Start is called before the first frame update
    void Start()
    {
        platformHeight = gameObject.GetComponent<SpriteRenderer>().size.y;
        gravityModifier = 0.0f;
    }  

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.transform.position.y > gameObject.transform.position.y + platformHeight/2) // Je detecte si la collision vient du dessus en comparant les Y des deux
        {
            if (!isFalling)
            {
                isFalling = true;
                StartCoroutine(Falling());
            }
        }
     }



    IEnumerator Falling()
    {
        yield return new WaitForSecondsRealtime(TimeBeforeFall);

        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 50);
        gravityModifier = 1.5f;

        Destroy(gameObject.GetComponent<BoxCollider2D>());

        yield return new WaitForSecondsRealtime(DestroyTime);

        if (Spawner != null)//Si la plateforme est lié à un spawner, envoie un message avant sa mort pour permettre sa réapparition
            Spawner.GetComponent<FallingPlatformSpawn>().IsPlatformAlive = false;
        Destroy(gameObject);
    }
}
