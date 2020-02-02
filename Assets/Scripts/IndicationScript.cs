using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicationScript : MonoBehaviour
{
    public List<SpriteRenderer> Left = new List<SpriteRenderer>();
    public List<SpriteRenderer> Right = new List<SpriteRenderer>();
    public List<SpriteRenderer> Front = new List<SpriteRenderer>();
    public List<SpriteRenderer> Back = new List<SpriteRenderer>();
    public List<SpriteRenderer> Up = new List<SpriteRenderer>();
    public List<SpriteRenderer> Down = new List<SpriteRenderer>();
    public List<SpriteRenderer> OrX = new List<SpriteRenderer>();
    public List<SpriteRenderer> OrY = new List<SpriteRenderer>();

    public float dist = 1f;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            Left[i].color = GameManager.instance.users[i].color;
            Left[i].transform.parent.position = new Vector3(dist,0f,0f);
            Right[i].color = GameManager.instance.users[i].color;
            Right[i].transform.parent.position = new Vector3(-dist, 0f, 0f);
            Front[i].color = GameManager.instance.users[i].color;
            Front[i].transform.parent.position = new Vector3(0f,0f,-dist);
            Back[i].color = GameManager.instance.users[i].color;
            Back[i].transform.parent.position = new Vector3(0f, 0f, dist);
            Up[i].color = GameManager.instance.users[i].color;
            Up[i].transform.parent.position = new Vector3(0f, dist, 0f);
            Down[i].color = GameManager.instance.users[i].color;
            Down[i].transform.parent.position = new Vector3(0f, -dist, 0f);
            OrX[i].color = GameManager.instance.users[i].color;
            OrY[i].color = GameManager.instance.users[i].color;
        }
    }

    public void enableLeftRight(IUsersInput input, float v)
    {
        if (v > 0.02f)
            Left[input.nActual - 1].enabled = true;
        else if(v < -0.02f)
            Right[input.nActual - 1].enabled = true;
        else
        {
            Left[input.nActual - 1].enabled = false;
            Right[input.nActual - 1].enabled = false;
        }
    }

    public void disableLeftRight(IUsersInput input)
    {
        Left[input.nActual - 1].enabled = false;
        Right[input.nActual - 1].enabled = false;
    }

    public void enableUpDown(IUsersInput input, float v)
    {
        if (v > 0.02f)
            Up[input.nActual - 1].enabled = true;
        else if (v < -0.02f)
            Down[input.nActual - 1].enabled = true;
        else
        {
            Down[input.nActual - 1].enabled = false;
            Up[input.nActual - 1].enabled = false;
        }
    }

    public void disableUpDown(IUsersInput input)
    {
        Up[input.nActual - 1].enabled = false;
        Down[input.nActual - 1].enabled = false;
    }

    public void enableFrontBack(IUsersInput input, float v)
    {
        if (v > 0.02f)
            Back[input.nActual - 1].enabled = true;
        else if (v < -0.02f)
            Front[input.nActual - 1].enabled = true;
        else
        {
            Front[input.nActual - 1].enabled = false;
            Back[input.nActual - 1].enabled = false;
        }
    }

    public void disableFrontBack(IUsersInput input)
    {
        Front[input.nActual - 1].enabled = false;
        Back[input.nActual - 1].enabled = false;
    }

    public void enableOrX(IUsersInput input, float v)
    {
        if(Mathf.Abs(v) > 0.02f)
            OrX[input.nActual - 1].enabled = true;
        else
            OrX[input.nActual - 1].enabled = false;
    }

    public void disableOrX(IUsersInput input)
    {
        OrX[input.nActual - 1].enabled = false;
    }

    public void enableOrY(IUsersInput input, float v)
    {
        if (Mathf.Abs(v) > 0.02f)
            OrY[input.nActual - 1].enabled = true;
        else
            OrY[input.nActual - 1].enabled = false;
    }

    public void disableOrY(IUsersInput input)
    {
        OrY[input.nActual - 1].enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
