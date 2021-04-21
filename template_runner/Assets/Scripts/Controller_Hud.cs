using System;
using UnityEngine;
using UnityEngine.UI;

public class Controller_Hud : MonoBehaviour
{
    public static bool gameOver = false;
    public Text distanceText;
    public Text gameOverText;
    public Text highscoreText;
    public static float distance = 0;
    public float maxRecord;
    void Start()
    {
        gameOver = false;
        distance = 0;
        distanceText.text = distance.ToString();
        int recordToInt = (int)GestorPersistencia.instancia.data.highscore;
        highscoreText.text = "Actual record :" + recordToInt;
        highscoreText.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0; //frena las cosas
            gameOverText.text = "Game Over \n Total Distance: " + Math.Round(distance).ToString();//redondeo el numero
            gameOverText.gameObject.SetActive(true); //aparecer el texto
            highscoreText.text = "Actual Record: " + distance.ToString();

            if(GestorPersistencia.instancia.data.highscore < maxRecord)
            {
                highscoreText.gameObject.SetActive(true);
                GestorPersistencia.instancia.data.highscore = maxRecord;
                int recordToInt = (int)GestorPersistencia.instancia.data.highscore;
            }
        }
        else //muestra el texto de arriba a la izquierda
        {
            distance += Time.deltaTime;
            distanceText.text = Math.Round(distance).ToString();
            int distanceToInt = (int)distance;
            distanceText.text = distanceToInt.ToString();
        }
        if(distance>maxRecord && distance> GestorPersistencia.instancia.data.highscore)
        {
            maxRecord = distance;
        }
    }
}
