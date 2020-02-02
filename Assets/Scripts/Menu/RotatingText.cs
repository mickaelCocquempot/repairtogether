using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingText : MonoBehaviour
{
	public float range;
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
		this.chrono += Time.deltaTime;
		if (this.chrono > this.time)
		{
			this.chrono -= this.time;

			Vector3 newRotation = this.angles;
			angles.z += Random.Range(-1.0f, 1.0f) * range;

			transform.eulerAngles = angles;
		}
	}
}
