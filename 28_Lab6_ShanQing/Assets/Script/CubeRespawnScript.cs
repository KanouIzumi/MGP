using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRespawnScript : MonoBehaviour
{

    public UIScript UIScore;

    // Start is called before the first frame update
    void Start()
    {
        
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
        //        SpawnCubes();
        //        UIScore.ScoreIncrement();
        //        Destroy(hit.collider.gameObject);
        //    }
        //}

        // for PC 
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                SpawnCubes();
                UIScore.ScoreIncrement();
                Destroy(hit.collider.gameObject);
            }
        }
    }

    void SpawnCubes()
    {
        Vector3 position = new Vector3(Random.Range(-4f, 4f), Random.Range(-5f, 5f));
        Instantiate(gameObject, position, Quaternion.identity);
    }
}
