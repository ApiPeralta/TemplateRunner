using System;
using UnityEngine;
using UnityEngine.UI;

public class Controller_Hud : MonoBehaviour
{
    public static bool gameOver = false;
    public Text distanceText;
    public Text gameOverText;
    private float distance = 0;
    void Start()
    {
        gameOver = false;
        distance = 0;
        distanceText.text = distance.ToString();
        gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0; //frena las cosas
            gameOverText.text = "Game Over \n Total Distance: " + Math.Round(distance).ToString();//redondeo el numero
            gameOverText.gameObject.SetActive(true); //aparecer el texto
        }
        else //muestra el texto de arriba a la izquierda
        {
            distance += Time.deltaTime;
            distanceText.text = Math.Round(distance).ToString();
        }
    }
}
