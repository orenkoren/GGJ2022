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
        if (Input.GetKeyDown(KeyCode.Q))
            currentProjectile = currentProjectile == positiveProjectile ? currentProjectile = negativeProjectile : currentProjectile = positiveProjectile;

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            GameObject projectile = Instantiate(currentProjectile, transform.position, transform.rotation);
            projectile.GetComponent<Projectile>().Init(GetComponent<Movement>().GetLookDirection() == LookDirection.Left ? -1 : 1);
            
        }
    }
}