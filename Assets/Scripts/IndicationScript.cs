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
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            Debug.Log(GameManager.instance.users[i].color);
            Left[i].color = GameManager.instance.users[i].color;
            Right[i].color = GameManager.instance.users[i].color;
            Front[i].color = GameManager.instance.users[i].color;
            Back[i].color = GameManager.instance.users[i].color;
            Up[i].color = GameManager.instance.users[i].color;
            Down[i].color = GameManager.instance.users[i].color;
            OrX[i].color = GameManager.instance.users[i].color;
            OrY[i].color = GameManager.instance.users[i].color;
        }
    }

    public void enableLeftRight(IUsersInput input, float v)
    {
        if (v > 0.05f)
            Left[input.nActual - 1].enabled = true;
        else if(v < -0.05f)
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
        if (v > 0.05f)
            Up[input.nActual - 1].enabled = true;
        else if (v < -0.05f)
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
        if (v > 0.05f)
            Front[input.nActual - 1].enabled = true;
        else if (v < -0.05f)
            Back[input.nActual - 1].enabled = true;
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
        if(Mathf.Abs(v) > 0.05f)
            OrX[input.nActual - 1].enabled = true;
    }

    public void disableOrX(IUsersInput input)
    {
        OrX[input.nActual - 1].enabled = false;
    }

    public void enableOrY(IUsersInput input, float v)
    {
        if (Mathf.Abs(v) > 0.05f)
            OrY[input.nActual - 1].enabled = true;
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
