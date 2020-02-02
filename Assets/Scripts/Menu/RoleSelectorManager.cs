using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            if(GameManager.instance.users[i].GetHorizontal() > 0.2f)
            {
                if(positions[0].isPlayerPresent(i))
                {
                    positions[0].removePlayer(i);
                    positions[1].addPlayer(i);
                }
                else if(positions[2].isPlayerPresent(i))
                {
                    positions[2].removePlayer(i);
                    positions[3].addPlayer(i);
                }
            }
            else if (GameManager.instance.users[i].GetHorizontal() < -0.2f)
            {
                if (positions[1].isPlayerPresent(i))
                {
                    positions[1].removePlayer(i);
                    positions[0].addPlayer(i);
                }
                else if (positions[3].isPlayerPresent(i))
                {
                    positions[3].removePlayer(i);
                    positions[2].addPlayer(i);
                }
            }
            else if (GameManager.instance.users[i].GetVertical() > 0.2f)
            {
                if (positions[2].isPlayerPresent(i))
                {
                    positions[2].removePlayer(i);
                    positions[0].addPlayer(i);
                }
                else if (positions[3].isPlayerPresent(i))
                {
                    positions[3].removePlayer(i);
                    positions[1].addPlayer(i);
                }
            }
            else if (GameManager.instance.users[i].GetVertical() < -0.2f)
            {
                if (positions[0].isPlayerPresent(i))
                {
                    positions[0].removePlayer(i);
                    positions[2].addPlayer(i);
                }
                else if (positions[1].isPlayerPresent(i))
                {
                    positions[1].removePlayer(i);
                    positions[3].addPlayer(i);
                }
            }
        }
    }
}
