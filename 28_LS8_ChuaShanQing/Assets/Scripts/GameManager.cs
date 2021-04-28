using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Animator animator;
    public float startDelayTime;
    public float levelTime;

    //Text in the game
    public Text scoreText;
    public Text livesText;
    public Text timeText;

    public int lives;
    public int score;

    private float elapsedTime;
    private float levelTimePassed;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        levelTimePassed = levelTime;
        timeText.text = "Time: " + levelTimePassed.ToString("0.00");

        livesText.text = "Lives: " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime > startDelayTime)
        {
            animator.SetTrigger("StartAnimation");
            levelTimePassed -= Time.deltaTime;
            timeText.text = "Time: " + levelTimePassed.ToString("0.00");

            if(levelTimePassed > levelTime)
            {
                SceneManager.LoadScene("GameWinScene");
            }
        }

        //Creating User Input com
        if(Input.GetMouseButtonDown(0))
        {
            //checking the state of the animation 
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Yellow_Animation"))
            {
                score++;
                scoreText.text = "Score: " + score;
                Debug.Log("You got yellow");
            }

            else
            {
                Debug.Log("Wrong");
                lives -=1;
                livesText.text = "Lives: " + lives;
            }
        }



        ////creating User Input for Phone
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        //checking the state of the animation 
        //        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Yellow_Animation"))
        //        {
        //            score++;
        //            scoreText.text = "Score: " + score;
        //            Debug.Log("You got yellow");
        //        }
        //    }

        //    else
        //    {
        //        Debug.Log("Wrong");
        //        lives -= 1;
        //        livesText.text = "Lives: " + lives;
        //    }
        //}

        if (levelTime < 0)
        {
            timeText.text = "Time: 0";
            SceneManager.LoadScene("");
        }
    }
}
