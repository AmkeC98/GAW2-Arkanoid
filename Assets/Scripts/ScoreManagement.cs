using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagement : MonoBehaviour
{
    public Text scoreText;
    private float score = 0;

    private void Start()
    {
        setScore(0);
    }

    private void setScore(float scoreCount)
    {
        score += scoreCount;
        scoreText.GetComponent<Text>().text = "Score: " + score.ToString();
    }
}
