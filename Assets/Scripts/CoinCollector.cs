using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    int score;
    public TextMeshProUGUI ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject Coin = collision.transform.gameObject;
        if(Coin.tag=="Coin")
        {
            score += 1;
            Destroy(Coin);
            ScoreText.text = "SCORE " + score;
        }
    }
}
