using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGerm_Controller : MonoBehaviour
{
    public GameManger instance;
    private AudioSource audioSource;
    public AudioClip[] AudioClipBGMArr;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        //// for mobile devices
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        GameManger.instance.score++;
        //        GameManger.instance.scoreText.text = "Scores: " + GameManger.instance.score;
        //        GameManger.instance.SpawnBadGerms();
        //        Destroy(hit.collider.gameObject);
        //    }
        //}


        // for PC 
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Bad_Germ")
            {
                audioSource.PlayOneShot(AudioClipBGMArr[0]);
                GameManger.instance.score++;
                GameManger.instance.scoreText.text = "Scores: " + GameManger.instance.score;
                GameManger.instance.SpawnBadGerms();
                Destroy(hit.collider.gameObject);
            }
        }

    }
}
