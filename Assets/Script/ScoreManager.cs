using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int score;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlayerPrefs.SetInt("Score", 0);
        }
        //score = PlayerPrefs.GetInt("Score", 0); // Load score

    }

    public void AddScore(int value)
    {
        score += value;
        PlayerPrefs.SetInt("Score", score); // Save score

    }


    public void SetScore(int resultScore)
    {
        Debug.Log("set");
        PlayerPrefs.SetInt("Score", resultScore); // Save score
    }
}
