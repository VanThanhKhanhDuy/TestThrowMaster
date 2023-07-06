using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMana : MonoBehaviour
{
    public void GoToMenu(){
        SceneManager.LoadScene("Menu");
    }
    public void GoToLevel1(){
        SceneManager.LoadScene("Level1");
    }
}
