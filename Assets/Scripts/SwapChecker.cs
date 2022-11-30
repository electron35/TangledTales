using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TileMap"))
        {
            gameObject.GetComponentInParent<PlayerController>().CanSwap = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TileMap"))
        {
            gameObject.GetComponentInParent<PlayerController>().CanSwap = true;
        }
    }
}
