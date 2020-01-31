using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventIntro : MonoBehaviour {

	public GameObject Texte;

	public GameObject blackScreen;
	
	public float fade = -1.0f;
	public float fadeTime = 0.5f;
	
	public bool bNextScene = false;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (bNextScene)
		{
			this.fade += Time.deltaTime / this.fadeTime;
			blackScreen.GetComponent<CanvasGroup>().alpha = 1.0f + this.fade;
			if (this.fade > 0.0f)
			{
				SceneManager.LoadScene("homeScene");
			}
			return;
		}

		if (Texte.GetComponent<TypingText>().finish)
		{
            if (Input.GetButtonDown("Fire1"))
            {
                this.bNextScene = true;
            }
		}
	}
}
