using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject Manager;
    public float speed;
    public float jumpStrength;

    private bool isGrounded;
    private float lookDirection;
    public float FallSpeed;
    public float JumpSpeed;
    private Vector3 respawnPoint;

    private void Start()
    {
        respawnPoint = transform.position;
    }
    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0)
            lookDirection = Input.GetAxis("Horizontal");
        transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * speed, transform.position.y, transform.position.z);
        jumpSpeedDefine();
    }
    private void Update()
    {
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
            rb.velocity += Vector3.up * Physics.gravity.y * FallSpeed * Time.deltaTime;
        }
        else if(rb.velocity.y > 0 && !Input.GetButton ("Jump"))
        {
            rb.velocity += Vector3.down * Physics.gravity.y * JumpSpeed * Time.deltaTime;
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
        if (collider.gameObject.CompareTag("RespawnPoint"))
        {
            changeRespawnPoint();
        }
        if (collider.gameObject.CompareTag("PositiveEnemy")||
            collider.gameObject.CompareTag("NegativeEnemy"))
        {
            respwan();
        }
    }

    private void OnCollisionExit(Collision collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void changeRespawnPoint()
    {
        respawnPoint = transform.position;
    }

    private void respwan()
    {
        Debug.Log("Respawn");
        transform.position = respawnPoint;
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
