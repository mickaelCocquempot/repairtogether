using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingText : MonoBehaviour {

	public string contentText;
	public float time = 0.1f;
	public float chrono;
	public int currentChar = 0;
	public TextMeshProUGUI textElement;
	public GameObject continueElement;
	public bool finish = false;

	// Use this for initialization
	void Start ()
	{
		this.textElement = this.GetComponent<TextMeshProUGUI>();
		this.contentText = this.textElement.text;
		this.textElement.text = "";
		continueElement.GetComponent<TextMeshProUGUI>().enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			this.currentChar = this.contentText.Length;
			this.textElement.text = contentText;
		}

		this.chrono += Time.deltaTime;
		if ((this.chrono > this.time) && (this.currentChar < this.contentText.Length))
		{
			this.chrono -= this.time;
			this.currentChar++;

			this.textElement.text = contentText.Substring(0, currentChar);
		}

		if (this.currentChar == this.contentText.Length)
		{
			this.continueElement.GetComponent<TextMeshProUGUI>().enabled = true;
			this.finish = true;
		}
	}
}
