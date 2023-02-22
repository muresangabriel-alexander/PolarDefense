using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using TMPro;

public class FinalScene : MonoBehaviour
{
    [SerializeField]
    private HighscoreScriptable highscore;

    public GameObject highscoreText;
    public GameObject scoreText; 

    public void Start()
    {
        highscoreText.GetComponent<TextMeshProUGUI>().text += highscore.Highscore;
        scoreText.GetComponent<TextMeshProUGUI>().text += highscore.CurrentScore;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
