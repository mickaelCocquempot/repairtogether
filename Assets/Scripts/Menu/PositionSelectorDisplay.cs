using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionSelectorDisplay : MonoBehaviour
{
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;

    public GameObject status;
    public GameObject status_icon;

    public List<Sprite> spritesPlayer1;
    public List<Sprite> spritesPlayer2;
    public List<Sprite> spritesPlayer3;
    public List<Sprite> spritesPlayer4;

    public int scoreGrowthSpeed;
    public Speed speed;

    public enum Speed
    {
        Slow,
        Fast
    }

    private struct Player
    {
        public Player(bool presence, float initScore)
        {
            present = presence;
            score = initScore;
            level = (int)initScore / 25;
        }

        public bool present;
        public float score;
        public int level;
    }

    private Player[] players;
    private float deltaTime;
    private int result;

    // Start is called before the first frame update
    void OnEnable()
    {
        status.SetActive(true);
        status_icon.SetActive(false);
        slot1.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        slot2.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        slot3.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        slot4.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        players = new Player[4] {
            new Player(false, 0),
            new Player(false, 0),
            new Player(false, 0),
            new Player(false, 0)
        };
        deltaTime = 0;
        result = -1;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            if(players[i].present)
            {
                Debug.Log("Player " + i + ": score - " + players[i].score + "   level - " + players[i].level);
                players[i].score = (players[i].score + scoreGrowthSpeed * Time.deltaTime > 100)? 100: players[i].score + scoreGrowthSpeed * Time.deltaTime;
                if((int)(players[i].score / 25) > players[i].level)
                {
                    if(addPlayerColor(i))
                    {
                        players[i].level++;
                    }
                    else
                    {
                        players[i].score = players[i].level * 25;
                    }
                }
                if(players[i].level == 3)
                {
                    status.SetActive(false);
                    status_icon.SetActive(true);
                    result = i;
                }
            }
        }
    }

    public bool addPlayer(int index)
    {
        if(!players[index].present)
        {
            players[index].present = addPlayerColor(index);
            players[index].score = 0;
            players[index].level = 0;
        }
        return players[index].present;
    }

    public void removePlayer(int index)
    {
        if(slot1.GetComponent<Image>().sprite == getPlayerSprite(0, index))
        {
            slot1.GetComponent<Image>().sprite = null;
            slot1.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
        if (slot2.GetComponent<Image>().sprite == getPlayerSprite(1, index))
        {
            slot2.GetComponent<Image>().sprite = null;
            slot2.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
        if (slot3.GetComponent<Image>().sprite == getPlayerSprite(2, index))
        {
            slot3.GetComponent<Image>().sprite = null;
            slot3.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
        if (slot4.GetComponent<Image>().sprite == getPlayerSprite(3, index))
        {
            slot4.GetComponent<Image>().sprite = null;
            slot4.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
        if (players[index].level == 3)
        {
            status.SetActive(true);
            status_icon.SetActive(false);
        }
        players[index].present = false;
    }

    public bool isPlayerPresent(int index)
    {
        return players[index].present;
    }

    bool addPlayerColor(int index)
    {
        if (slot1.GetComponent<Image>().color.a < 0.5f)
        {
            setSlotColor(0, index);
        }
        else if (slot2.GetComponent<Image>().color.a < 0.5f)
        {
            setSlotColor(1, index);
        }
        else if (slot3.GetComponent<Image>().color.a < 0.5f)
        {
            setSlotColor(2, index);
        }
        else if (slot4.GetComponent<Image>().color.a < 0.5f)
        {
            setSlotColor(3, index);
        }
        else
        {
            return false;
        }
        return true;
    }

    void setSlotColor(int indexSlot, int indexPlayer)
    {
        Image image;
        switch (indexSlot)
        {
            case 0:
                image = slot1.GetComponent<Image>();
                break;
            case 1:
                image = slot2.GetComponent<Image>();
                break;
            case 2:
                image = slot3.GetComponent<Image>();
                break;
            case 3:
                image = slot4.GetComponent<Image>();
                break;
            default:
                image = slot1.GetComponent<Image>();
                break;
        }
        image.color = new Color(1, 1, 1, 1);
        image.sprite = getPlayerSprite(indexSlot, indexPlayer);
    }

    Sprite getPlayerSprite(int indexSlot, int indexPlayer)
    {
        switch(indexPlayer)
        {
            case 0:
                return spritesPlayer1[indexSlot];
                break;
            case 1:
                return spritesPlayer2[indexSlot];
                break;
            case 2:
                return spritesPlayer3[indexSlot];
                break;
            case 3:
                return spritesPlayer4[indexSlot];
                break;
            default:
                return spritesPlayer1[indexSlot];
                break;
        }
    }

    int getResult()
    {
        for (int i = 0; i < 4; i++)
        {
            if(players[i].level == 3)
            {
                return i;
            }
        }
        return -1;
    }
}
