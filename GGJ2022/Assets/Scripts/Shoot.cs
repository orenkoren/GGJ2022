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
    public Sprite imagePlus;
    public Sprite imgaeMinus;

    private bool isPlus = true;
    private GameObject currentProjectile;
    private bool canShoot = true;
    private PlayerManager playerManager;

    private void Start()
    {
        currentProjectile = positiveProjectile;
        playerManager = GameWorld.Instance.GetManager<PlayerManager>();
        playerManager.SetPlayerCharge(ElectricCharge.Positive);
    }

    private void Update()
    {
        if (!canShoot)
            return;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentProjectile == positiveProjectile)
            {
                currentProjectile = negativeProjectile;
                playerManager.SetPlayerCharge(ElectricCharge.Negative);
            }
            else
            {
                currentProjectile = positiveProjectile;
                playerManager.SetPlayerCharge(ElectricCharge.Positive);
            }
            swapWeaponImage();
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            GameObject projectile = Instantiate(currentProjectile, transform.position, transform.rotation);
            projectile.GetComponent<Projectile>().Init(Player.GetComponent<Movement>().GetLookDirection() == LookDirection.Left ? -1 : 1);
            
        }
    }
    private void swapWeaponImage()
    {
        if (isPlus)
        {
            isPlus = false;
            GetComponent<SpriteRenderer>().sprite = imgaeMinus;
        }
        else
        {
            isPlus = true;
            GetComponent<SpriteRenderer>().sprite = imagePlus;
        }
    }
    public void EnableWeapons()
    {
        canShoot = true;
    }

    public void DisableWeapons()
    {
        canShoot = false;
    }
}