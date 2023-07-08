using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMana : MonoBehaviour
{
    public static void GoToMenu(){
        SceneManager.LoadScene("Menu");
    }
    public static void GoToLevel1(){
        SceneManager.LoadScene("Level1");
    }
    public static void SceneManagement(){
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "Level1"){
            SceneManager.LoadScene("Level2");
        }
        else if (currentSceneName == "Level2"){
            SceneManager.LoadScene("VictoryScene");
        }
    }
    public static void GameOver(){
        SceneManager.LoadScene("GameOver");
    }
}
