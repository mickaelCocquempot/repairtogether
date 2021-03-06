﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoleSelectorManager : MonoBehaviour
{
    public int nbPlayers;
    public List<PositionSelectorDisplay> positions;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < GameManager.instance.usersN; i++)
        {
            positions[0].addPlayer(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < GameManager.instance.usersN; i++)
        {
            if (GameManager.instance.users[i].GetHorizontal() > 0.2f)
            {
                if (positions[0].isPlayerPresent(i))
                {
                    if (positions[1].addPlayer(i))
                    {
                        positions[0].removePlayer(i);
                    }
                }
                else if (positions[2].isPlayerPresent(i))
                {
                    if (positions[3].addPlayer(i))
                    {
                        positions[2].removePlayer(i);
                    }
                }
            }
            else if (GameManager.instance.users[i].GetHorizontal() < -0.2f)
            {
                if (positions[1].isPlayerPresent(i))
                {
                    if (positions[0].addPlayer(i))
                    {
                        positions[1].removePlayer(i);
                    }
                }
                else if (positions[3].isPlayerPresent(i))
                {
                    if (positions[2].addPlayer(i))
                    {
                        positions[3].removePlayer(i);
                    }
                }
            }
            else if (GameManager.instance.users[i].GetVertical() < -0.2f)
            {
                if (positions[2].isPlayerPresent(i))
                {
                    if (positions[0].addPlayer(i))
                    {
                        positions[2].removePlayer(i);
                    }
                }
                else if (positions[3].isPlayerPresent(i))
                {
                    if (positions[1].addPlayer(i))
                    {
                        positions[3].removePlayer(i);
                    }
                }
            }
            else if (GameManager.instance.users[i].GetVertical() > 0.2f)
            {
                if (positions[0].isPlayerPresent(i))
                {
                    if (positions[2].addPlayer(i))
                    {
                        positions[0].removePlayer(i);
                    }
                }
                else if (positions[1].isPlayerPresent(i))
                {
                    if (positions[3].addPlayer(i))
                    {
                        positions[1].removePlayer(i);
                    }
                }
            }

        }

        int fullResult = 0;
        for (int i = 0; i < 4; i++)
        {
            int result = positions[i].getResult();
            if (result > -1)
            {
                //Debug.Log("Got Result for player: " + result);
                fullResult++;
                GameManager.instance.users[result].speed = (positions[i].speed == PositionSelectorDisplay.Speed.Fast) ? 5 : 3;
            }
        }
        if (fullResult == GameManager.instance.usersN)
        {
            SceneManager.LoadScene("WorkPlace");
        }

    }
}
