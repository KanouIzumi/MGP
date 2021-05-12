using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public static GameManger instance;

    Vector2 screenBounds;

    public Text scoreText;
    public Text livesText;
    public Text timeText;


    public float levelTime;
    public int lives;
    public int score;

    public GameObject badGerm;
    public GameObject goodGerm;

    private float elapsedTime;
    private float levelTimePassed;


    // Start is called before the first frame update
    void Start()
    {
        //this is the germ spawn
        if (instance == null)
        {
            instance = this;
        }



        //This code is for when this game is imported into other phone it will resize the game into that phone size
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        //This code is for the timing for the game
        levelTimePassed = levelTime;
        timeText.text = "Time: " + levelTimePassed.ToString("0.00");

        livesText.text = "Lives: " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        //this is to check for the time
        elapsedTime += Time.deltaTime;

        //When the time start it will spawn the good and bad germs
        if(elapsedTime > 0)
        {
        
            levelTimePassed -= Time.deltaTime;
            timeText.text = "Time: " + levelTimePassed.ToString("0.00");
        }

        //this is for the win condition
        if (levelTimePassed < 0 || score > 10)
        {
            SceneManager.LoadScene("WinScene");
        }

        //this is for the lose condition
        if(lives ==0)
        {
            SceneManager.LoadScene("LoseScene");
        }


    }

    //Spawning the bad germs
    public void SpawnBadGerms()
    {
        Vector3 position = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), Random.Range(-screenBounds.y, screenBounds.y), 0);
        var NewBadgerms = Instantiate(badGerm, position, Quaternion.identity);
    }

    //spawning the good germs
    public void SpawnGoodGerms()
    {
        Vector3 position = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), Random.Range(-screenBounds.y, screenBounds.y), 0);
        var NewGoodGerms = Instantiate(goodGerm, position, Quaternion.identity);
    }
}
