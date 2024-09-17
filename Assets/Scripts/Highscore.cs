using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Highscore : MonoBehaviour
{
    // Objeto a ser instanciado
    [SerializeField] private TextMeshProUGUI highScoreText;



    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();

    }

    

    
}
