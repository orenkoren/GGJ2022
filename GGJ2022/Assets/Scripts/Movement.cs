using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
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
        if(transform.position.y <= -30)
        {
            Respawn();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        if(GetLookDirection() == LookDirection.Left)
        {
            transform.rotation = new Quaternion(0,180,0,0);
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -1);
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1);
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
        if (collider.gameObject.CompareTag("PositiveEnemy")||
            collider.gameObject.CompareTag("NegativeEnemy"))
        {
            Respawn();
        }
    }

    private void OnCollisionExit(Collision collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RespawnPoint"))
        {
            changeRespawnPoint();
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
        GameWorld.Instance.SetRespawnPoint(respawnPoint, "Level1");
    }

    private void Respawn()
    {
        GameWorld.Instance.Respawn();
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
