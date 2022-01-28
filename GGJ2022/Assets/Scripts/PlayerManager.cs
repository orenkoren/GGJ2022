using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject Player;
    private Vector3 startPosition;
    private void Start()
    {
        startPosition = Player.transform.position;
    }
    public Vector3 GetPlayerPosition()
    {
        return Player.transform.position;
    }
    public Vector3 GetRespawnPosition()
    {
        return startPosition;
    }
}
