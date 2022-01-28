using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorld : MonoBehaviour
{
    public static GameWorld Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);

        else
            Instance = this;
    }
    public void RespawnEnemies()
    {
        GetComponent<EnemiesRespawnManager>().RespawnEnemies();
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
}
