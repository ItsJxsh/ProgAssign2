using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;


// Note the difference between collision vs trigger:
// Collision does a physics-based collision resulting in Unity preventing the two objects from overlapping.
// Trigger simply tests for overlap so you can respond to an event (ie doubling speed if in overlapping area)
public class CollisionDetection : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject timer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Speedup"))
        {
            gameObject.GetComponent<Player>().speed *= 1.5f;
            gameObject.GetComponent<Player>().items.Add("Speedup");
            Debug.Log("Your speed increased by 1.5x!");
            gameObject.GetComponent<Player>().itemscollected++;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("key"))
        {
            Debug.Log("Your Gained A Key!");
            gameObject.GetComponent<Player>().items.Add("Key");
            Destroy(collision.gameObject);
            gameObject.GetComponent<Player>().itemscollected++;
        }

        if (collision.CompareTag("Boxes") && gameObject.GetComponent<Player>().items.Contains("Key"))
        {
            gameObject.GetComponent<Player>().items.Remove("Key");
            gameObject.GetComponent<Player>().items.Add("UsedKey");
            Debug.Log("Your Unlocked the Door!");
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Finish"))
        {
            
            timer.GetComponent<timer>().gameActive = false;
            Destroy(collision.gameObject);
        }
    }
}