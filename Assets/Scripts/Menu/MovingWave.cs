using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingWave : MonoBehaviour
{
	public float time;

	public GameObject wave_1;
	public GameObject wave_2;
	public GameObject wave_3;
	public GameObject wave_4;

	public int currentWave = 0;

	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update()
	{

		wave_1.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, getAlpha(Time.realtimeSinceStartup, 0.0f));
		wave_2.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, getAlpha(Time.realtimeSinceStartup, 1.0f));
		wave_3.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, getAlpha(Time.realtimeSinceStartup, 2.0f));
		wave_4.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, getAlpha(Time.realtimeSinceStartup, 3.0f));
		
	}

	float getAlpha(float t, float k)
	{
		return Mathf.Sin(t*time - k / 4.0f * Mathf.PI) * 2.0f - 1.0f;
	}
}
