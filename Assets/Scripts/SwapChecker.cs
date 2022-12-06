using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapChecker : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TileMap"))
        {
            gameObject.GetComponent<PlayerController>().CanSwap = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TileMap"))
        {
            gameObject.GetComponent<PlayerController>().CanSwap = true;
        }
    }
}
