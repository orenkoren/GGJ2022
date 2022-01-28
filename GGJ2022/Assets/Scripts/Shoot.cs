using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject positiveProjectile;
    public GameObject negativeProjectile;
    public GameObject Player;
    public Material NegativeWeapon;
    public Material PositiveWeapon;
   
    private GameObject currentProjectile;

    private void Start()
    {
        currentProjectile = positiveProjectile;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
             GetComponent<MeshRenderer>().material = NegativeWeapon;
            if (currentProjectile == positiveProjectile)
            {
                currentProjectile = negativeProjectile;
                GetComponent<MeshRenderer>().material = PositiveWeapon;
            }
            else
            {
                currentProjectile = positiveProjectile;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            GameObject projectile = Instantiate(currentProjectile, transform.position, transform.rotation);
            projectile.GetComponent<Projectile>().Init(Player.GetComponent<Movement>().GetLookDirection() == LookDirection.Left ? -1 : 1);
            
        }
    }
}