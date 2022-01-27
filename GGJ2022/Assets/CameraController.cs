using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraDistance = 10f;
    public Transform Player;
    void Awake()
    {
        GetComponent<Camera>().orthographicSize = 2f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(Player.transform.position.x, Player.position.y, Player.transform.position.z - cameraDistance);
    }
}
