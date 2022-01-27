using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(
            transform.position, new Vector3(transform.position.x + 2000,
             transform.position.y, transform.position.z), step);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
