using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventWarning : MonoBehaviour {

	public GameObject Element_01;
	public GameObject Element_02;
	public GameObject Element_03;
	public GameObject Element_04;
	public GameObject Element_05;
	public GameObject Element_06;

	public GameObject blackScreen;
	
	public float fade = -1.0f;
	public float fadeTime = 0.5f;
	
	public bool startGame = false;

	// Use this for initialization
	void Start ()
	{
		Element_02.SetActive(false);
		Element_03.SetActive(false);
		Element_04.SetActive(false);
		Element_05.SetActive(false);
		Element_06.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (startGame)
		{
			this.fade += Time.deltaTime / this.fadeTime;
			blackScreen.GetComponent<CanvasGroup>().alpha = 1.0f + this.fade;
			if (this.fade > 0.0f)
			{
				SceneManager.LoadScene("gameIntro");
			}
			return;
		}

		if (Element_01.GetComponent<TypingText>().finish)
		{
			Element_03.SetActive(true);
			Element_04.SetActive(true);
			Element_02.SetActive(true);
		}
		if (Element_02.GetComponent<TypingText>().finish)
		{
			Element_05.SetActive(true);
		}
		if (Element_05.GetComponent<TypingText>().finish)
		{
			Element_06.SetActive(true);
		}

		if (Input.GetButtonDown("Fire1"))
		{
			if (Element_06.activeSelf)
			{
				this.startGame = true;
			}
		}
	}
}
