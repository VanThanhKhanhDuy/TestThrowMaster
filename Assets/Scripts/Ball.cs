using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D playerSpawn;
    public GameObject nextPlayer;
    public float releaseTime = .15f;
    public float maxDragDistance = 2f;
    private bool isPressed = false;
    
    void Update(){
        if(isPressed){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Vector3.Distance(mousePos, playerSpawn.position) > maxDragDistance)
                rb.position = playerSpawn.position + (mousePos - playerSpawn.position).normalized * maxDragDistance;
            else
                rb.position = mousePos;
        }
        int aliveEnemies = EnemyScript.EnemiesAlive;
        // Debug.Log("Alive:" + aliveEnemies);
        if (aliveEnemies <= 0)
        {
            StartCoroutine(Won());
        }
    }
    void OnMouseDown(){
        // Debug.Log("Nhap chuot");
        isPressed = true;
        rb.isKinematic = true;
    }
    void OnMouseUp(){
        isPressed = false;
        rb.isKinematic = false;
        StartCoroutine(Release());
    }
    IEnumerator Release(){
        yield return new WaitForSeconds(releaseTime);
            GetComponent<SpringJoint2D>().enabled = false;
            this.enabled = false;
        yield return new WaitForSeconds(2f);
            CheckNextPlayer();
        yield return new WaitForSeconds(1.5f);
            Destroy(gameObject);
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
        if(nextPlayer == null && aliveEnemies != 0){
            Lose();
        }
    }
    void Win(){
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "Level1"){
            SceneManager.LoadScene("Level2");
        }
        else if (currentSceneName == "Level2"){
            SceneManager.LoadScene("VictoryScene");
        }
    }
    void Lose(){
        SceneManager.LoadScene("GameOver");
    }
    void CheckNextPlayer(){
        if(nextPlayer != null){
            nextPlayer.SetActive(true);
            CheckWinLose();
        }
        else{
            CheckWinLose();
        }
        
    }

}
