using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public int enemiesCount = 5;
    public Text enemiesToEliminate;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        enemiesToEliminate.text = "Enemies: " + enemiesCount.ToString();
    }

    public void reduceEnemies()
    {
        --enemiesCount;
        enemiesToEliminate.text = "Enemies: " + enemiesCount.ToString();
        if(enemiesCount <= 0)
        {
            StateManager.changeScene("GameOver");
        }
    }
}
