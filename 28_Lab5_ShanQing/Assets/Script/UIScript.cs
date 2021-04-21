using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text UIScoreText;
    int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        UIScoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreIncrement()
    {
        score += 1;
        UIScoreText.text = "Score: " + score.ToString();
    }
}
