using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            GameObject projective = Instantiate(projectile, transform.position, transform.rotation);
            int direction = 1;
            if (GetComponent<Movement>().GetLookDirection() > 0)
            {
                direction = -1;
            }
            else if(GetComponent<Movement>().GetLookDirection() < 0)
            {
                direction = 1;
            }
        }
    }
}