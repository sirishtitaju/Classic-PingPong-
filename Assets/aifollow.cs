using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aifollow : MonoBehaviour {

	public float speed;
	private Transform target;
	private float maxY =  3.9f, minY = -3.9f;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 ballpos = target.position;

		Vector2 temp = transform.position;
		if(temp.y >= maxY)
		temp.y = maxY;

		if(temp.y <= minY)
		temp.y = minY;
		transform.position = temp;

		float ran = Random.Range(0,2);

		if(Vector2.Distance(transform.position,target.position)>1.2 && Vector2.Distance(transform.position,target.position) < 10.5f  )
		transform.position = Vector2.MoveTowards(new Vector2(transform.position.x,transform.position.y),new Vector2(transform.position.x,target.position.y), speed*Time.deltaTime);
	   
	}
}
