using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public Text TimerText;
    public Text HighScoreText;
    public Text UIScoreText;

    int score = 0;

    int totalGameTime = 0;
    int timeInt;
    float time = 11f;

    // Start is called before the first frame update
    void Start()
    {
        HighScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeInt = Mathf.FloorToInt(time % 60);
        TimerText.text = "Time: " + timeInt.ToString();


        if (time < 0)
        {
            TimerText.text = "Time: 0";
            SceneManager.LoadScene("WinScene");
        }

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
    public void ScoreIncrement()
    {
        score += 1;
        UIScoreText.text = "Score: " + score.ToString();
    }
}
