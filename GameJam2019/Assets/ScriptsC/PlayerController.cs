using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 200f;
    public Rigidbody2D rb;
    public bool isGround = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            transform.position += new Vector3(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, 0f);
            {

            }
        }
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
