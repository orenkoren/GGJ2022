using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpStrength;

    private bool isGrounded;

    private void Start()
    {
        speed = 1f;
        jumpStrength = 100f;
        isGrounded = true;
    }
    private void FixedUpdate()
    {
        var input = Input.GetAxis("Horizontal");
        transform.position = new Vector2(transform.position.x + input * speed, transform.position.y);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            Jump();
    }

    private void Jump()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpStrength, 0));
        isGrounded = false;
    }

    private void OnCollision(Collision collider)
    {
        Debug.Log("Collided with: " + collider.gameObject.tag);
        if (collider.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
