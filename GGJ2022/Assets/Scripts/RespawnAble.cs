using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnAble : MonoBehaviour
{    
    void Start()
    {
        GameWorld.Instance.GetManager<RespawnManager>().AddObjectToRespawnList(transform.position, transform.name, gameObject);
    }
}
