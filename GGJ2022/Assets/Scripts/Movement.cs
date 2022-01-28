using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpStrength;

    private bool isGrounded;
    private float lookDirection;

    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0)
            lookDirection = Input.GetAxis("Horizontal");
        transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * speed, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            Jump();
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
