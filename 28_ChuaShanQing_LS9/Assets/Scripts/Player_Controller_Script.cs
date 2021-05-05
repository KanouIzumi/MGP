using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller_Script : MonoBehaviour
{

    public Rigidbody2D rb;

    public float moveSpeed;
    public float jumpPower;

    public Transform groundcheck;
    public float groundcheckradius;
    public LayerMask ground;
    private bool onGround;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(groundcheck.position, groundcheckradius, ground);
    }



    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            SceneManager.LoadScene("GameScene");
        }



    }
}
