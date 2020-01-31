using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrollScript : MonoBehaviour
{
	public float fadeTime;
	public float finalFade;
	public float startTime;
	public float speed;
	public float stopPos;
	public GameObject subScroll;
	public GameObject continueText;

	public GameObject audioSource;

	public float chrono;
	public float chronoFade;

	public float hold;

	// Use this for initialization
	void Start ()
	{
		chrono = 0.0f;
		chronoFade = 0.0f;
		this.GetComponent<CanvasGroup>().alpha = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (hold < 25.0f)
		{
			hold += Time.deltaTime;
		}
		else
		{
			chrono += Time.deltaTime;

			if (chrono < fadeTime)
			{
				//this.GetComponent<CanvasGroup>().alpha = Mathf.Min(chrono / fadeTime, 1.0f);
			}
			else
			{
				if (Input.GetButtonDown("Fire1"))
				{
					SceneManager.LoadScene("menu");
				}

				this.GetComponent<CanvasGroup>().alpha = Mathf.Min((chrono - fadeTime) / fadeTime, 1.0f);
				continueText.GetComponent<CanvasGroup>().alpha = Mathf.Min((chrono - fadeTime) / fadeTime, 1.0f);

				float newPos = (chrono - fadeTime) * speed;
				if (newPos > stopPos)
				{
					if (chronoFade > finalFade)
					{
						this.GetComponent<CanvasGroup>().alpha = 1.0f - (chronoFade - finalFade) / finalFade;
						audioSource.AddComponent<AudioSource>().volume = 1.0f - (chronoFade - finalFade) / finalFade;
						if (chronoFade > finalFade * 2.0f)
						{
							SceneManager.LoadScene("menu");
						}
					}
					subScroll.transform.position = new Vector3(0.0f, newPos, 0.0f);
					chronoFade += Time.deltaTime;
				}
				else
				{
					this.transform.position = new Vector3(0.0f, newPos, 0.0f);
				}
			}
			
		}
	}
}
