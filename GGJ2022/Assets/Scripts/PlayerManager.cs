using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject Player;

    public Vector3 GetPlayerPosition()
    {
        return Player.transform.position;
    }
}
