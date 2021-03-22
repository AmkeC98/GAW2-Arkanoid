using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    // Movement Speed
    public float speed = 100.0f;
    public GameObject playerBall;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    private void Update()
    {
        if (playerBall.transform.position.y <= -150.0f)
        {
            PlayGameOver();
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        // ascii art:
        // 1  -0.5  0  0.5   1  <- x value
        // ===================  <- racket
        //
        return (ballPos.x - racketPos.x) / racketWidth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Hit the Racket?
        if (collision.gameObject.name == "Racket")
        {
            // Calculate hit Factor
            float x = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }

    private void PlayGameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
