using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    // private static EnemyManager instance;
    // public int EnemiesAlive { get; private set; }

    // private void Awake()
    // {
    //     if (instance == null)
    //     {
    //         instance = this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    // private void Start()
    // {
    //     CountEnemiesAlive();
    // }

    // public void EnemySpawned()
    // {
    //     EnemiesAlive++;
    // }

    // public void EnemyDied()
    // {
    //     EnemiesAlive--;

    //     if (EnemiesAlive <= 0)
    //     {
    //         Debug.Log("Level won!");
    //     }
    // }

    // private void CountEnemiesAlive()
    // {
    //     EnemiesAlive = GameObject.FindGameObjectsWithTag("Enemy").Length;
    // }
}
