using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpStrength;
    private void Update()
    {
        var input = Input.GetAxis("Horizontal");
        transform.position = new Vector3(transform.position.x + input * speed, transform.position.y, transform.position.z);
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void Jump()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpStrength, 0));
    }
}
