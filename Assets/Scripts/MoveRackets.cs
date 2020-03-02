using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRackets : MonoBehaviour {
	public float speed = 30;
	private Vector3 mousePosition;
	private float maxY =  4.27f, minY = -4.27f;
	public string axis = "Vertical";
    void FixedUpdate()
    {
        //float v = Input.GetAxisRaw(axis);
        //GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;

		Vector2 temp = transform.position;
		if(temp.y >= maxY)
		temp.y = maxY;

		if(temp.y <= minY)
		temp.y = minY;
		transform.position = temp;

		if (Input.GetMouseButton(0)) {
           // mousePosition = Input.mousePosition;
			Vector3 tempX = Input.mousePosition;
			if(tempX.y >= maxY)
			{
			   tempX.y = tempX.y - 60f;
			}
			if(tempX.y <= -maxY+20f)
			{
			   tempX.y = tempX.y + 60f;
			}
		    mousePosition = tempX;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			
			//Vector2.MoveTowards(new Vector2(transform.position.x,transform.position.y),new Vector2(transform.position.x,tempX.y), speed*Time.deltaTime);
            transform.position = Vector2.Lerp(transform.position,new Vector3(transform.position.x,mousePosition.y,mousePosition.z), speed);
        }
 
    }
}
