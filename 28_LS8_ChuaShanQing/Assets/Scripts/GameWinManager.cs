using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWinManager : MonoBehaviour
{
    public Text scoreText;

    public Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + PlayerPrefs.GetInt("score");
        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("Highscore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
