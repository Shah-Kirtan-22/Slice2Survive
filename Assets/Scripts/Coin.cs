using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [HideInInspector]
    public int coinCount = 0;

    private Text scoreCount;

    private void Start()
    {
        scoreCount = GameObject.FindGameObjectWithTag("scoreCount").GetComponent<Text>();
    }

    private void Update()
    {
        transform.Rotate(180 * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            coinCount++;
            DisplayScore();
            Destroy(gameObject);
        }
    }

    private void DisplayScore()
    {
        scoreCount.text = "Score: " + coinCount.ToString();
    }
}
