using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodGerm_Controller : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // for mobile devices
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameManger.instance.lives--;
                GameManger.instance.livesText.text = "Lives: " + GameManger.instance.lives;
                Destroy(hit.collider.gameObject);
            }
        }


        // for PC 
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameManger.instance.lives--;
                GameManger.instance.livesText.text = "Lives: " + GameManger.instance.lives;
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
