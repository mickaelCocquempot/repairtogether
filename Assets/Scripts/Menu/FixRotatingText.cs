using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotatingText : MonoBehaviour
{
	public float speed;
	public Vector3 angles;
	public float time = 0.5f;
	public float chrono;

	// Use this for initialization
	void Start()
	{
		this.angles = transform.eulerAngles;
		this.chrono = 0.0f;
	}

	// Update is called once per frame
	void Update()
	{
		angles.z += speed * Time.deltaTime;
		transform.eulerAngles = angles;
		this.chrono += Time.deltaTime;
		if (this.chrono > this.time)
		{
			this.chrono -= this.time;
			speed = -speed;
		}
	}
}
