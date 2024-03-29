using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<SpawnerInfo> spawnInfo;

    private bool hasSpawned = false;
    private void OnTriggerEnter(Collider other)
    {
        if (hasSpawned)
            return;
        foreach (var info in spawnInfo)
        {
            Instantiate(info.toSpawn, info.location.position, info.location.rotation);
        }
        hasSpawned = true;
    }
}

[Serializable]
public class SpawnerInfo
{
    public GameObject toSpawn;
    public Transform location;
}