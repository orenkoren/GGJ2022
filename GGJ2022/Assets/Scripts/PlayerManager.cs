using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject Player;
    public static PlayerManager Instance;

    private ElectricCharge playerCharge;

    public Vector3 GetPlayerPosition()
    {
        return Player.transform.position;
    }

    public void DisableWeapons()
    {
        Player.GetComponentInChildren<Shoot>().DisableWeapons();
    }

    public void EnableWeapons()
    {
        Player.GetComponentInChildren<Shoot>().EnableWeapons();
    }

    public ElectricCharge GetPlayerCurrentCharge()
    {
        return playerCharge;
    }

    public void SetPlayerCharge(ElectricCharge charge)
    {
        playerCharge = charge;
    }
    public void SetPlayerLocation(Vector3 pos)
    {
        Player.transform.position = pos;
    }
}
