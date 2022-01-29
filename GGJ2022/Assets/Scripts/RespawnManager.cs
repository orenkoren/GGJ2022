using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    private static Vector3 reSpawnPosition;
    private static string sceneName;

    public static RespawnManager Instance;

    public void SetRespawn(Vector3 pos, string scence)
    {
        reSpawnPosition = pos;
        sceneName = scence;
    }
    
    public Vector3 GetRespawnPoint()
    {
        return reSpawnPosition;
    }
    public string GetRespawnScene()
    {
        return sceneName;
    }
}