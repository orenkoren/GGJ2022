using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
            Instantiate(projectile, transform.position, transform.rotation);
    }
}
