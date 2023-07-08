using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D playerSpawn;
    public GameObject nextPlayer;
    public float releaseTime = 0.15f;
    public float maxDragDistance = 2f;
    private bool isPressed = false;

    private void Update(){
        int aliveEnemies = EnemyScript.EnemiesAlive;
        if (isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mousePos, playerSpawn.position) > maxDragDistance)
                rb.position = playerSpawn.position + (mousePos - playerSpawn.position).normalized * maxDragDistance;
            else
                rb.position = mousePos;
        }

        CheckWinLose();
    }

    private void OnMouseDown(){
        isPressed = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp(){
        isPressed = false;
        rb.isKinematic = false;
        StartCoroutine(Release());
    }

    private IEnumerator Release(){
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
        yield return new WaitForSeconds(3f);
        CheckNextPlayer();
    }

    IEnumerator Won(){
        yield return new WaitForSeconds(2f);
        Win();
    }

    void CheckWinLose(){
        int aliveEnemies = EnemyScript.EnemiesAlive;
        if (aliveEnemies <= 0)
        {
            StartCoroutine(Won());
        }

        if (nextPlayer == null && aliveEnemies != 0)
        {
            Lose();
            Debug.Log("lose");
        }
    }

    void Win(){
        SceneMana.SceneManagement();
        Debug.Log("win");
    }

    void Lose(){
        SceneMana.GameOver();
    }

    void CheckNextPlayer(){
        if (nextPlayer != null)
        {
            nextPlayer.SetActive(true);
        }else{
        CheckWinLose();
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
