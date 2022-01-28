using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpStrength;

    private bool isGrounded;
    private float lookDirection;
    private float fallSpeed = 3.5f;
    private float jumpSpeed = 2f;

    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0)
            lookDirection = Input.GetAxis("Horizontal");
        transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * speed, transform.position.y, transform.position.z);
    }

    private void Update()
    {

        jumpSpeedDefine();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void jumpSpeedDefine()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb.velocity.y < 0) // on the air
        {
            rb.velocity += Vector3.up * Physics.gravity.y * fallSpeed * Time.deltaTime;
        }
        else if(rb.velocity.y > 0 && !Input.GetButton ("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * jumpSpeed * Time.deltaTime;
        }
    }

    private void Jump()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpStrength, 0));
    }

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public LookDirection GetLookDirection()
    {
        return lookDirection < 0 ? LookDirection.Left : LookDirection.Right;
    }
}

public enum LookDirection
{
    Left,
    Right
}
