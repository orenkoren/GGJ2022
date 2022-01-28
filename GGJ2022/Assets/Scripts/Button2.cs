using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : MonoBehaviour
{
    public MovingPlatform platform;

    private void OnCollisionEnter(Collision collision)
    {
        platform.ResetLocation();
    }
}