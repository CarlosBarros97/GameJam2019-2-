using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Animation variables
    public Animator playerAnimator;
    private bool isMoving = false;


    // Other variables
    public float moveSpeed = 3f;
    public float jumpForce = 200f;
    public Rigidbody2D rb;
    public bool isGround = true;
    private SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {// Move player if arrow keys are pressed
            transform.position += new Vector3(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, 0f);
            isMoving = true;

            if(Input.GetAxis("Horizontal") < 0)
            {
                playerSprite.flipX = true;
            }
            else if(Input.GetAxis("Horizontal") > 0) {
                playerSprite.flipX = false;
            }
        }
        else
        {
            isMoving = false;
        }
        playerAnimator.SetBool("isMoving", isMoving);

        // Jump if spacebar is pressed and checks if player has already jumped
        if (Input.GetButton("Jump")&&isGround)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isGround = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
    }
}
