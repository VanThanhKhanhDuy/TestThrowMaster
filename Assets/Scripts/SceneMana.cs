using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMana : MonoBehaviour
{
    public static class SceneNames
{
    public const string Level1 = "Level1";
    public const string Level2 = "Level2";
    public const string VictoryScene = "VictoryScene";
    // Add more scene names as needed
}
    public static void SceneManagement(){
         string currentSceneName = SceneManager.GetActiveScene().name;
        switch (currentSceneName)
        {
            case SceneNames.Level1:
                SceneManager.LoadScene(SceneNames.Level2);
                break;
            
            case SceneNames.Level2:
                SceneManager.LoadScene(SceneNames.VictoryScene);
                break;  

        default:
            break;
        }
    }
    public static void GoToMenu(){
        SceneManager.LoadScene("Menu");
    }
    public static void GoToLevel1(){
        SceneManager.LoadScene("Level1");
    }
    
    public static void GameOver(){
        SceneManager.LoadScene("GameOver");
    }
}
