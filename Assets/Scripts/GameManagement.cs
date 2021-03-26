using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    public Text scoreText;
    public GameObject ball;
    private float score = 0;
    private List<GameObject> blocks = new List<GameObject>();
    private AudioSource myAudio;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
        setScore(0);

        foreach (GameObject block in GameObject.FindGameObjectsWithTag("Breakable"))
        {
            blocks.Add(block);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Breakable")
        {
            myAudio.Play();
            Destroy(collision.gameObject);
            blocks.Remove(collision.gameObject);
            setScore(1);

            if (blocks.Count == 0)
            {
                SceneManager.LoadScene("WinScene");
            }
        }
    }

    private void setScore(float scoreCount)
    {
        score += scoreCount;
        scoreText.GetComponent<Text>().text = "Score: " + score.ToString();
    }
}
