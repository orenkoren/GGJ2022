using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public GameObject PositiveEnemyPref;
    public GameObject NegativeEnemyPref;
    public static RespawnManager Instance;

    private List<Respawn> ObjectToRspawn;

    public void Start()
    {
        ObjectToRspawn = new List<Respawn>();
    }

    public class Respawn
    {
        public Respawn(Vector3 pos, string name)
        {
            SpawnPosition = pos;
            Name = name;
        }
        public Vector3 SpawnPosition;
        public string Name;
    }

    public void AddObjectToRespawnList(Vector3 pos, string name)
    {
        ObjectToRspawn.Add(new Respawn(pos, name));
    }

    public void RespawnObjects()
    {
        foreach (Respawn objToRespawn in ObjectToRspawn)
        {
            if (objToRespawn.Name == "PositiveEnemy")
            {
                Instantiate(PositiveEnemyPref, objToRespawn.SpawnPosition, new Quaternion(0, 0, 0, 0));
            }
            else if(objToRespawn.Name == "NegativeEnemy")
            {
                Instantiate(NegativeEnemyPref, objToRespawn.SpawnPosition, new Quaternion(0, 0, 0, 0));
            }
            else if (objToRespawn.Name == "Platform")
            {
                GameObject obj = GameObject.Find("Platform");
                Debug.Log(obj.transform.name + " Respawn!~!");
                obj.transform.position = objToRespawn.SpawnPosition;
            }
        }
        ObjectToRspawn.Clear();
    }
}