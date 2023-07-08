using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject enemyDeadEffect;
    public float health;
    private static int enemiesAlive = 0;
    public static int EnemiesAlive{
        get { return enemiesAlive; }
    }

    private void OnEnable(){
        enemiesAlive++;
    }

    private void OnDisable(){
        enemiesAlive--;
    }

    private void OnCollisionEnter2D(Collision2D colInfo){
        if (colInfo.relativeVelocity.magnitude > health)
        {
            Die();
        }
    }

    private void Die(){
        gameObject.SetActive(false);
        Instantiate(enemyDeadEffect, transform.position, Quaternion.identity);
    }  
}
