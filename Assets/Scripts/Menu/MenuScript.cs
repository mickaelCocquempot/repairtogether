using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
	public GameObject newGame;
	public GameObject options;
	public GameObject credits;
	public GameObject quit;

	public GameObject menuGroup;
	public GameObject creditGroup;
	public GameObject controlsGroup;
	public GameObject blackScreen;
	public GameObject audioSource;

	public int state = 0;
	public float fade = -1.0f;
	public float fadeTime = 0.5f;

	public int currentSelection = 0;
	public bool startGame = false;

	public float waitTime = 0.5f;
	public float waitChrono = 0.0f;

	// Use this for initialization
	void Start ()
	{
		SelectText(newGame);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (startGame)
		{
			this.fade += Time.deltaTime / this.fadeTime;
			blackScreen.GetComponent<CanvasGroup>().alpha = 1.0f + this.fade;
			audioSource.GetComponent<AudioSource>().volume = 1.0f - (1.0f + this.fade);
			if (this.fade > 0.0f)
			{
				SceneManager.LoadScene("gameWarning");
			}
			return;
		}

		updateFade(this.state);

		if (waitChrono > 0.0f)
		{
			waitChrono -= Time.deltaTime;
		}
		else
		{
			waitChrono = 0.0f;
		}

		switch (this.state)
		{
			case 0:
				if ((Input.GetAxis("Vertical") < 0.0f) && (waitChrono == 0.0f))
				{
					UnselectText(GetElement(currentSelection));
					currentSelection++;
					currentSelection %= 4;
					SelectText(GetElement(currentSelection));
					waitChrono = waitTime;
				}
				if ((Input.GetAxis("Vertical") > 0.0f) && (waitChrono == 0.0f))
				{
					UnselectText(GetElement(currentSelection));
					currentSelection += 3;
					currentSelection %= 4;
					SelectText(GetElement(currentSelection));
					waitChrono = waitTime;
				}
				if (Input.GetAxis("Vertical") == 0.0f)
				{
					waitChrono = 0.0f;
				}

				if (Input.GetButtonDown("Fire1"))
				{
					switch (currentSelection)
					{
						case 0:
							startGame = true;
							break;
						case 1:
							this.state = 2;
							break;
						case 2:
							this.state = 1;
							break;
						case 3:
							Application.Quit();
							break;
					}
				}
				break;
			case 1:
			case 2:
				if (Input.GetButtonDown("Fire1"))
				{
					this.state = 0;
				}
				break;
		}
	}

	GameObject GetElement(int selection)
	{
		switch (selection)
		{
			case 1:
				return this.options;
				break;
			case 2:
				return this.credits;
				break;
			case 3:
				return this.quit;
				break;
			default:
				return this.newGame;
				break;
		}
	}

	void SelectText(GameObject element)
	{
		TextMeshProUGUI textElement = element.GetComponent<TextMeshProUGUI>();
		textElement.text = "( " + textElement.text + " )";
	}

	void UnselectText(GameObject element)
	{
		TextMeshProUGUI textElement = element.GetComponent<TextMeshProUGUI>();
		textElement.text = textElement.text.Substring(2, textElement.text.Length - 4);
	}

	void updateFade(int state)
	{
		if (state != 0)
		{
			this.fade += Time.deltaTime / this.fadeTime;
		}
		else
		{
			this.fade -= Time.deltaTime / this.fadeTime;
		}
		this.fade = Mathf.Clamp(this.fade, -1.0f, 1.0f);

		menuGroup.GetComponent<CanvasGroup>().alpha = Mathf.Abs(Mathf.Clamp(this.fade, -1.0f, 0.0f));
		if (state == 0)
		{
			creditGroup.GetComponent<CanvasGroup>().alpha = Mathf.Min(Mathf.Abs(Mathf.Clamp(this.fade, 0.0f, 1.0f)), creditGroup.GetComponent<CanvasGroup>().alpha);
			controlsGroup.GetComponent<CanvasGroup>().alpha = Mathf.Min(Mathf.Abs(Mathf.Clamp(this.fade, 0.0f, 1.0f)), controlsGroup.GetComponent<CanvasGroup>().alpha);
		}
		if (state == 1)
		{
			creditGroup.GetComponent<CanvasGroup>().alpha = Mathf.Abs(Mathf.Clamp(this.fade, 0.0f, 1.0f));
		}
		if (state == 2)
		{
			controlsGroup.GetComponent<CanvasGroup>().alpha = Mathf.Abs(Mathf.Clamp(this.fade, 0.0f, 1.0f));
		}
	}
}
