using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 10;
    public float jumpForce = 50;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(x, y, 0);

        Walk(dir);

        if (Input.GetButtonDown("Jump")) {
            
        }
    }

    private void Walk(Vector3 dir) {
        playerRb.velocity = (new Vector3(dir.x * speed, playerRb.velocity.y, 0));
    }

    private void Jump(Vector3 dir) {
        playerRb.velocity = new Vector3(playerRb.velocity.x, 0, 0);
        playerRb.velocity += dir * jumpForce;
    }
}
