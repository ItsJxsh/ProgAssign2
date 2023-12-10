using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    public float countdown = 30;
    public TMP_Text t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown > 0) 
        {
            countdown -= Time.deltaTime;
        }
        double b = System.Math.Round(countdown, 1);
        t.text = countdown.ToString();


     }
}

