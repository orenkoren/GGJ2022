using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpStrength;

    private bool isGrounded;
    private float lookDirection;
    private void Start()
    {
        speed = 1f;
        jumpStrength = 400f;
        isGrounded = true;
        lookDirection = 1;
    }
    private void FixedUpdate()
    {
        lookDirection = Input.GetAxis("Horizontal");
        transform.position = new Vector2(transform.position.x + lookDirection * speed, transform.position.y);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            Jump();
    }

    private void Jump()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpStrength, 0));
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collider)
    {
        Debug.Log("Collided with: " + collider.gameObject.tag);
        if (collider.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    public float GetLookDirection()
    {
        return lookDirection;
    }
}
