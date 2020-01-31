using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBack : MonoBehaviour
{
	public float maxX;
	public float maxY;

	public int moveState;
	public float time;
	public float chrono;

	public Vector3 posFrom;
	public Vector3 posTo;

	// Use this for initialization
	void Start ()
	{
		this.transform.position = new Vector3(-maxX, -maxY, 0.0f);
		chrono = time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (chrono >= time)
		{
			chrono = 0.0f;
			float xPos;
			float yPos;
			switch (Random.Range(0,3))
			{
				case 0:
					xPos = Random.Range(-maxX, maxX);
					posFrom = new Vector3(xPos, -maxY, 0.0f);
					posTo = new Vector3(xPos, maxY, 0.0f);
					break;
				case 1:
					xPos = Random.Range(-maxX, maxX);
					posFrom = new Vector3(xPos, maxY, 0.0f);
					posTo = new Vector3(xPos, -maxY, 0.0f);
					break;
				case 2:
					yPos = Random.Range(-maxY, maxY);
					posFrom = new Vector3(-maxX, yPos, 0.0f);
					posTo = new Vector3(maxX, yPos, 0.0f);
					break;
				case 3:
					yPos = Random.Range(-maxY, maxY);
					posFrom = new Vector3(maxX, yPos, 0.0f);
					posTo = new Vector3(-maxX, yPos, 0.0f);
					break;
			}
		}

		chrono += Time.deltaTime;

		this.transform.position = posFrom * chrono / time + posTo * (1.0f - (chrono / time));
		this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, Mathf.Pow((1 - Mathf.Cos(chrono/time * 2.0f * Mathf.PI)) / 2.0f, 0.25f));
	}
}
