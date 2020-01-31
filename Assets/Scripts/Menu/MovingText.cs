using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingText : MonoBehaviour
{
	public float range;
	public Vector3 position;
	public float time = 0.5f;
	public float chrono;

	// Use this for initialization
	void Start ()
	{
		this.position = transform.position;
		this.chrono = 0.0f;
}
	
	// Update is called once per frame
	void Update ()
	{
		this.chrono += Time.deltaTime;
		if (this.chrono > this.time)
		{
			this.chrono -= this.time;

			Vector3 newPosition = this.position;
			newPosition.x += Random.Range(-1.0f, 1.0f) * range;
			newPosition.y += Random.Range(-1.0f, 1.0f) * range;

			transform.position = newPosition;
		}
	}
}
