using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI textScore;
    public void AddScore()
    {
        score++;
        textScore.text = "Score: " + score.ToString();
    }
}
