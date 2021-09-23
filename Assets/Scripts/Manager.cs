using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public int lives = 10;
    public GameObject gameOverCanvas;
    public TMP_Text livesText;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        RestartGame();
    }

    public void LoseLife()
    {
        lives--;

        livesText.text = "Lives : " + lives.ToString();

        if(lives <= 0)
        {
            //Game over
            gameOverCanvas.SetActive(true);
        }
    }

    public void RestartGame()
    {
        lives = 10;
        livesText.text = "Lives : " + lives.ToString();
        gameOverCanvas.SetActive(false);
    }
}
