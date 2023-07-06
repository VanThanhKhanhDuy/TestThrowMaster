using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public GameObject enemyDeadEffect;
    public float health; 
    public static int EnemiesAlive = 0;
    void Start() {
        EnemiesAlive++;
    }
    void OnCollisionEnter2D(Collision2D colInfo){
        // Debug.Log(colInfo.relativeVelocity.magnitude);
        if(colInfo.relativeVelocity.magnitude > health){
            Die();
        }
    }
    void Die(){
        Instantiate(enemyDeadEffect, transform.position, Quaternion.identity);
        EnemiesAlive--;
        if(EnemiesAlive <= 0)
            Debug.Log("Level won!");
        Destroy(gameObject);
    }
}
