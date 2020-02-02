using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
	public GameObject playersNumber;
	public GameObject newGame;
	public GameObject rules;
	public GameObject controls;
	public GameObject credits;
	public GameObject quit;

	public GameObject menuGroup;
	public GameObject creditGroup;
	public GameObject controlsGroup;
	public GameObject rulesGroup;
	public GameObject blackScreen;
	public GameObject audioSource;

	public int state = 0;
	public float fade = -1.0f;
	public float fadeTime = 0.5f;
	public int players = 2;

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
				GameManager.instance.usersN = players;
				SceneManager.LoadScene("MenuRoles");
			}
			return;
		}

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
				if ((Input.GetAxis("Vertical") < -0.1f) && (waitChrono == 0.0f))
				{
					UnselectText(GetElement(currentSelection));
					currentSelection++;
					currentSelection %= 5;
					SelectText(GetElement(currentSelection));
					waitChrono = waitTime;
				}
				if ((Input.GetAxis("Vertical") > 0.1f) && (waitChrono == 0.0f))
				{
					UnselectText(GetElement(currentSelection));
					currentSelection += 4;
					currentSelection %= 5;
					SelectText(GetElement(currentSelection));
					waitChrono = waitTime;
				}
				if (Input.GetAxis("Vertical") == 0.1f)
				{
					waitChrono = 0.0f;
				}

				if ((Input.GetAxis("Horizontal") < -0.1f) && (waitChrono == 0.0f))
				{
					if(players > 2)
					{
						players--;
						TextMesh textElement = playersNumber.GetComponent<TextMesh>();
						textElement.text = "◄ " + players + "Players ►";
						waitChrono = waitTime;
					}
				}
				if ((Input.GetAxis("Horizontal") > 0.1f) && (waitChrono == 0.0f))
				{
					if (players < 4)
					{
						players++;
						TextMesh textElement = playersNumber.GetComponent<TextMesh>();
						textElement.text = "◄ " + players + "Players ►";
						waitChrono = waitTime;
					}
				}
				if (Input.GetAxis("Horizontal") == 0.1f)
				{
					waitChrono = 0.0f;
				}

				bool fire1 = false;
                for(int i = 0; i < 4; i++)
                {
					if (SystemInfo.operatingSystemFamily == OperatingSystemFamily.MacOSX)
						fire1 |= Input.GetButtonDown("P" + (i+1) + "_X_MAC");
					else
						fire1 |= Input.GetButtonDown("P" + (i+1) + "_X_MS");
				}
				if (fire1)
				{
					switch (currentSelection)
					{
						case 0:
							startGame = true;
							break;
						case 1:
						case 2:
						case 3:
							menuGroup.SetActive(false);
							SetSelectionActive(currentSelection, true);
							this.state = 2;
							break;
						case 4:
							Application.Quit();
							break;
					}
				}
				break;
			case 1:
			case 2:
				if (Input.GetButtonDown("Fire1"))
				{
					menuGroup.SetActive(true);
					SetSelectionActive(currentSelection, false);
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
				return this.rules;
				break;
			case 2:
				return this.controls;
				break;
			case 3:
				return this.credits;
				break;
			case 4:
				return this.quit;
				break;
			default:
				return this.newGame;
				break;
		}
	}

	void SetSelectionActive(int selection, bool active)
	{
		switch (selection)
		{
			case 1:
				this.rulesGroup.SetActive(active);
				break;
			case 2:
				this.controlsGroup.SetActive(active);
				break;
			case 3:
				this.creditGroup.SetActive(active);
				break;
			default:
				this.menuGroup.SetActive(active);
				break;
		}
	}

	void SelectText(GameObject element)
	{
		TextMesh textElement = element.GetComponent<TextMesh>();
		textElement.text = "> " + textElement.text + " <";
	}

	void UnselectText(GameObject element)
	{
		TextMesh textElement = element.GetComponent<TextMesh>();
		textElement.text = textElement.text.Substring(2, textElement.text.Length - 4);
	}
}
