using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float countdownTime = 30f; 
    public Text countdownText; 
    private bool gameEnded = false;

    void Start()
    {
        UpdateCountdownUI();
    }

    void Update()
    {
        if (gameEnded) return;

        
        countdownTime -= Time.deltaTime;
        UpdateCountdownUI();

        
        if (countdownTime <= 0)
        {
            EndGame(false); 
        }

        
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            EndGame(true); 
        }
    }

    void UpdateCountdownUI()
    {
        countdownText.text = "Tiempo: " + Mathf.Clamp(countdownTime, 0, countdownTime).ToString("F2") + "s";
    }

    void EndGame(bool won)
    {
        gameEnded = true;

        if (won)
        {
            SceneManager.LoadScene(1);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true; 

        }
        else
        {
            SceneManager.LoadScene(2);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;


        }
    }
}
