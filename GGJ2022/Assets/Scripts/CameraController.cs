using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 cameraOffset = new Vector3(0, 0, 10f);
    public Transform Player;
    void Awake()
    {
        GetComponent<Camera>().orthographicSize = 2f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Player.transform.position + cameraOffset;
    }
}
