using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEnter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            GameWorld.Instance.SetRespawnPoint(new Vector3(-12, 30, 0), "Level2");
            GameSceneManager.OpenLevel2Scence();
        }
    }
}
