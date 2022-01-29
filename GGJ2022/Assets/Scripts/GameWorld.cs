using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWorld : MonoBehaviour
{
    public static GameWorld Instance;
    public GameObject Player;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);

        else
            Instance = this;
    }
    public void Respawn()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single); //GetComponent<RespawnManager>().GetRespawnScene()
        GetComponent<PlayerManager>().SetPlayerLocation(new Vector3(-20,2,0));//GetComponent<RespawnManager>().GetRespawnPoint()
    }

    public T GetManager<T>()
    {
        return GetComponent<T>();
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
        GetComponent<RespawnManager>().SetRespawn(pos, SceneManager.GetActiveScene().name);
    }
}
