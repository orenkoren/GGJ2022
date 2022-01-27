using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;

    private void Update()
    {
        int direction = 1;
        if(GetComponent<Movement>().GetLookDirection() < 1) // shoot left
        {
            direction = -1;
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
            Instantiate(projectile, transform.position, transform.rotation);
    }
}
