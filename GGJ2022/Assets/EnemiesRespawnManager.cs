using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesRespawnManager : MonoBehaviour
{
    public GameObject PositiveEnemyPref;
    public GameObject NegativeEnemyPref;
    public static EnemiesRespawnManager Instance;

    private List<Enemy> EnemiesToRspawn;

    public void Start()
    {
        EnemiesToRspawn = new List<Enemy>();
    }

    public class Enemy
    {
        public Enemy(Vector3 pos, bool isPositive)
        {
            spawnPosition = pos;
            isPositiveEnemy = isPositive;
        }
        public Vector3 spawnPosition;
        public bool isPositiveEnemy;
    }

    public void AddEnemyToRespawnList(Vector3 pos, bool isPositive)
    {
        EnemiesToRspawn.Add(new Enemy(pos, isPositive));
    }

    public void RespawnEnemies()
    {
        foreach (Enemy enemy in EnemiesToRspawn)
        {
            if (enemy.isPositiveEnemy)
            {
                Instantiate(PositiveEnemyPref, enemy.spawnPosition, new Quaternion(0, 0, 0, 0));
            }
            else
            {
                Instantiate(NegativeEnemyPref, enemy.spawnPosition, new Quaternion(0, 0, 0, 0));
            }
        }
        EnemiesToRspawn.Clear();
    }
}