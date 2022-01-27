using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpStrength;

    private bool isGrounded;

    private void Update()
    {
        var input = Input.GetAxis("Horizontal");
        transform.position = new Vector3(transform.position.x + input * speed, transform.position.y, transform.position.z);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            Jump();
    }

    private void Jump()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpStrength, 0));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
            isGrounded = true;

    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
            isGrounded = false;
    }
}
