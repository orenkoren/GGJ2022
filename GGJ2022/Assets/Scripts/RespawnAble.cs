using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnAble : MonoBehaviour
{
    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameWorld.Instance.GetManager<RespawnManager>().AddObjectToRespawnList(startPosition, transform.name);
    }
}
