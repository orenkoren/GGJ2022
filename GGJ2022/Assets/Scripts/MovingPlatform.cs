using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform playerPullLocation;
    public Transform resetLocation;
    public float speed = 5f;
    public ElectricCharge charge;

    private Vector3 currentDestination;

    private void Start()
    {
        currentDestination = resetLocation.position;
    }

    private void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentDestination, step);
    }

    public void ResetLocation()
    {
        currentDestination = resetLocation.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameWorld.Instance.CollidedWithOpoositeCharge(charge, collision.gameObject))
            currentDestination = playerPullLocation.position;
    }
}