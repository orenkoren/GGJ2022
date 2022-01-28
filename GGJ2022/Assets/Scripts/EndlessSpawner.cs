using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class EndlessSpawner : MonoBehaviour
{
    public GameObject toSpawn;
    public Transform location;
    public float interval;

    private float counter = 0;
    private bool hasActivated = false;

    private void Update()
    {
        if (!hasActivated)
            return;
        counter += Time.deltaTime;
        if(counter >= interval)
        {
            counter = 0;
            Instantiate(toSpawn, location.position, location.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if(!hasActivated)
            Instantiate(toSpawn, location.position, location.rotation);
        hasActivated = true;
    }
}*/
