using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour {
    public float speed = 20;
	private float maxY =  4.8f, minY = -4.8f, minX = -8.66f, maxX = 8.66f;
	public Text ScoreText;
	public Text LifeText;
	public Text highScore;
	private int score = 0;
	private int Life = 5;
	private bool isGameover;
    void Start() {
        // Initial Velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;

		//highscore
		highScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore");
    }
	void Update() {
		Vector2 temp = transform.position;
		if(temp.y >= maxY)
		temp.y = maxY;

		if(temp.y <= minY)
		temp.y = minY;
		transform.position = temp;	

		if(temp.x >= maxX)
		temp.x = maxX;

		if(temp.x <= minX)
		temp.x = minX;
		transform.position = temp;	

		if(isGameover == true)
		 SceneManager.LoadScene("YourLevel1");
		
	}
	float hitFactor(Vector2 ballPos, Vector2 racketPos,
                    float racketHeight) {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }
	void OnCollisionEnter2D(Collision2D col) {
    // Note: 'col' holds the collision information. If the
    // Ball collided with a racket, then:
    //   col.gameObject is the racket
    //   col.transform.position is the racket's position
    //   col.collider is the racket's collider

    // Hit the left Racket?
    if (col.gameObject.name == "RacketLeft") {
        // Calculate hit Factor
		score++;
		ScoreText.text = "Score: " + score;
        float y = hitFactor(transform.position,
                            col.transform.position,
                            col.collider.bounds.size.y);

        // Calculate direction, make length=1 via .normalized
        Vector2 dir = new Vector2(1, y).normalized;

        // Set Velocity with dir * speed
        GetComponent<Rigidbody2D>().velocity = dir * speed;
    }

    // Hit the right Racket?
    if (col.gameObject.name == "RacketRight") {
        // Calculate hit Factor
        float y = hitFactor(transform.position,
                            col.transform.position,
                            col.collider.bounds.size.y);

        // Calculate direction, make length=1 via .normalized
        Vector2 dir = new Vector2(-1, y).normalized;

        // Set Velocity with dir * speed
        GetComponent<Rigidbody2D>().velocity = dir * speed;
    }
	if(col.gameObject.name == "WallLeft")
	{
		Life--;
		LifeText.text = "Life: " + Life;
		if(Life == 0)
		{
			isGameover = true;
		}
	}
	if (col.gameObject.name == "WallRight")
	{
		score+=5;
		ScoreText.text = "Score: " + score;
	}
	if(score > PlayerPrefs.GetInt("HighScore"))
	{
	PlayerPrefs.SetInt("HighScore",score);
	highScore.text = "HighScore: " + score;
	}
}
}
