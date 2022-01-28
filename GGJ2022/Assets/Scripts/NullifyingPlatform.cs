using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullifyingPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            GameWorld.Instance.GetManager<PlayerManager>().DisableWeapons();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            GameWorld.Instance.GetManager<PlayerManager>().EnableWeapons();
    }
}
