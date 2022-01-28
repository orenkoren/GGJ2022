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
        public Respawn(Vector3 pos, string name, GameObject i_gameObject)
        {
            SpawnPosition = pos;
            Name = name;
            gameObject = i_gameObject;
        }
        public Vector3 SpawnPosition;
        public string Name;
        public GameObject gameObject;
    }

    public void AddObjectToRespawnList(Vector3 pos, string name, GameObject gameObject)
    {
        ObjectToRspawn.Add(new Respawn(pos, name, gameObject));
    }

    public void RespawnObjects()
    {
        foreach (Respawn objToRespawn in ObjectToRspawn)
        {
            Debug.Log(objToRespawn.gameObject.transform.name + " Has Respawn");
            if (objToRespawn.Name == "PositiveEnemy")
            {
                Instantiate(PositiveEnemyPref, objToRespawn.SpawnPosition, new Quaternion(0, 0, 0, 0));
            }
            else if(objToRespawn.Name == "NegativeEnemy")
            {
                Instantiate(NegativeEnemyPref, objToRespawn.SpawnPosition, new Quaternion(0, 0, 0, 0));
            }
            else
            {
                objToRespawn.gameObject.transform.position = objToRespawn.SpawnPosition;
            }
        }
        ObjectToRspawn.Clear();
    }
}