using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWorld : MonoBehaviour
{
    public static GameWorld Instance;
    public GameObject Player;

    private static bool isRespawnSet = false;
    private static Vector3 reSpawnPosition;
    private static string sceneName;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);

        else
            Instance = this;
    }

    public static Vector3 GetPlayerRespawnPosition()
    {
        return reSpawnPosition;
    }

    public void Respawn()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public T GetManager<T>()
    {
        return GetComponent<T>();
    }
    public static bool IsRespawnSet()
    {
        return isRespawnSet;
    }
    public bool CollidedWithOpoositeCharge(ElectricCharge current, GameObject other)
    {
        return current == ElectricCharge.Positive && other.gameObject.CompareTag(ElectricCharge.Negative.ToString()) ||
                    current == ElectricCharge.Negative && other.gameObject.CompareTag(ElectricCharge.Positive.ToString());
    }
    public static Vector3 GarbagePosition()
    {
        return new Vector3(-1000, -1000, -1000);
    }
    public void SetRespawnPoint(Vector3 pos)
    {
        reSpawnPosition = pos;
        isRespawnSet = true;
        sceneName = SceneManager.GetActiveScene().name;
    }
}
