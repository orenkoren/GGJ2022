using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public int direction = 1;

    public void Init(int firingDirection)
    {
        direction = firingDirection;
    }

    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(
            transform.position, new Vector3(transform.position.x + direction * 2000,
             transform.position.y, transform.position.z), step);
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
