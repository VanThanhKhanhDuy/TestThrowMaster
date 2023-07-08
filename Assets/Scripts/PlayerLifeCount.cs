using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeCount : MonoBehaviour
{
    public Text playerLifeCount;
    public int lifeCount = 3;
    private void Start() {
        UpdatePlayerCount();
    }
    private void UpdatePlayerCount(){
        playerLifeCount.text = lifeCount.ToString();
    }
    public void DecreaseLifeCount()
    {
        lifeCount--;
        UpdatePlayerCount();
    }
}
