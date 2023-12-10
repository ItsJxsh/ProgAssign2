using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEnd : MonoBehaviour
{
    public TMP_Text t;
    public static double time;
    public static int items;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= 0) 
        {
            t.text = ("You Win!\nTime Remaining: " + time + " seconds" + "\nItems Collected: " + items + " / 4");
        }
        else
        {
            t.text = ("Game Over!\nTime Remaining: " + time + " seconds" + "\nItems Collected: " + items + " / 4");
        }

    }
}
