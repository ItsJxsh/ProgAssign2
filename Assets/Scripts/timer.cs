using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    public float countdown = 30;
    public TMP_Text t;
    public bool gameActive = true;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown > 0 && gameActive) 
        {
            countdown -= Time.deltaTime;
        }
        double b = System.Math.Round(countdown, 1);
        t.text = b.ToString();

        if (gameActive == false) 
        {
            GameEnd.time = b;
            GameEnd.items = player.GetComponent<Player>().itemscollected;
            SceneManager.LoadScene("End");

        }
     }
}

