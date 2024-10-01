using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public int score;

    public int highScore { get; set; }
   

    //SCORE AREA

    public Text textScore;
    public Text textHighScore;


    private void Awake()
    {
        textHighScore.text = "Best: "+ GetHighScore();
    }
    public void StartGame()
    {
        gameStarted = true;
        FindAnyObjectByType<Road>().Startbuilding();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))  //start game when press Enter button
        {
            StartGame();
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);

    }

    public void IncreaseScore()
    { 
        score++;
        textScore.text = $"SCORE: {score}";
        if (score >= highScore) 
        {
            PlayerPrefs.SetInt("Highscore", score);
            textHighScore.text="Best: "+score.ToString();
        }
    }

    public int GetHighScore()
    {
        int i = PlayerPrefs.GetInt("Highscore");
        return i;
    }
}
