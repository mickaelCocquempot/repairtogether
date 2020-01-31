using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchImg : MonoBehaviour {

    public Sprite ImgBase;
    public Sprite ImgSwitch;
    public float switchTime;

    private float timer;

	// Use this for initialization
	void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                GetComponent<Image>().sprite = ImgBase;
            }
        }
	}

    public void switchImg()
    {
        Debug.Log("img switch");
        timer = switchTime;
        GetComponent<Image>().sprite = ImgSwitch;
    }
}
