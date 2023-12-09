using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Note the difference between collision vs trigger:
// Collision does a physics-based collision resulting in Unity preventing the two objects from overlapping.
// Trigger simply tests for overlap so you can respond to an event (ie doubling speed if in overlapping area)
public class CollisionDetection : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Speedup"))
        {
            gameObject.GetComponent<Player>().speed *= 2;
            gameObject.GetComponent<Player>().score += 500;
            Debug.Log("Gained 500 Points! Current Score:" + gameObject.GetComponent<Player>().score);
            Destroy(collision.gameObject);
        }
    }
}