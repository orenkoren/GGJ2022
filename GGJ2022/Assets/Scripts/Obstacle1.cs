using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle1 : MonoBehaviour
{
    public Transform destination;
    public float speed;

    private bool hasActivated;
    private bool hasReached;
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (!hasActivated)
            return;
        float step = speed * Time.deltaTime;
        if(!hasReached)
        transform.position = Vector3.MoveTowards(transform.position, destination.position, step);
        if (hasReached)
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, step);

    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.CompareTag(ElectricCharge.Negative.ToString()))
            hasActivated = true;

        if (collision.gameObject.transform == destination)
        {
            hasReached = true;
            collision.transform.position = GameWorld.GarbagePosition(); // change position and not destroy to avoid prefab instance for respawn
        }
    }
}
