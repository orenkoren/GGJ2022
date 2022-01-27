using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject positiveProjectile;
    public GameObject negativeProjectile;

    private GameObject currentProjectile;

    private void Start()
    {
        currentProjectile = positiveProjectile;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            currentProjectile = currentProjectile == positiveProjectile ? currentProjectile = negativeProjectile : currentProjectile = positiveProjectile;

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            GameObject projective = Instantiate(currentProjectile, transform.position, transform.rotation);
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