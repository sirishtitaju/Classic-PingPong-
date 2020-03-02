using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMovement : MonoBehaviour {

	public float forceX,forceY;

	[SerializeField]
	private Rigidbody2D Ball;
 
    // Use this for initialization
    void Start () {
		//Ball.AddForce(new Vector2(forceX,forceY));
	}
   
    // Update is called once per frame
    void Update () {
		Ball.AddForce(new Vector2(forceX,forceY));
       //Movement();
    }
	// void Movement() 
	// {
	// 	float inputX = Input.GetAxisRaw("Horizontal");
    //     float inputY = Input.GetAxisRaw("Vertical");
	// 	float velocity = Mathf.Abs(Ball.velocity.x);

	// 	if(inputX > 0)
	// 	{
	// 		//moving right
	// 		if(velocity < maxVelocity)
	// 		{
	// 			forceX = speed;
	// 		}
	// 	}
	// 	else if(inputX < 0)
	// 	{
	// 		//moving right
	// 		if(velocity < maxVelocity)
	// 		{
	// 			forceX = -speed;
	// 		}
	// 	}

	// 	if(inputY > 0)
	// 	{
	// 		//moving right
	// 		if(velocity < maxVelocity)
	// 		{
	// 			forceY = speed;
	// 		}
	// 	}
	// 	else if(inputY < 0)
	// 	{
	// 		//moving right
	// 		if(velocity < maxVelocity)
	// 		{
	// 			forceY = -speed;
	// 		}
	// 	}
	// 	Ball.AddForce(new Vector2(forceX,forceY));
	// }
	
}
