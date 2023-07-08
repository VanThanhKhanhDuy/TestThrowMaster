using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public GameObject enemyDeadEffect;
    public float health;
    public static int EnemiesAlive = 0;

    void OnEnable()
    {
        EnemiesAlive++;
    }

    void OnDisable()
    {
        EnemiesAlive--;
    }

    void OnCollisionEnter2D(Collision2D colInfo){
        if (colInfo.relativeVelocity.magnitude > health)
        {
            Die();
        }
    }

    void Die(){
        Instantiate(enemyDeadEffect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        Debug.Log(EnemiesAlive);
    }
}
