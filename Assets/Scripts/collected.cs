using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class collected : MonoBehaviour
{
    public TMP_Text text;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ("Items Collected: " + player.GetComponent<Player>().itemscollected + " / 4");
    }
}
