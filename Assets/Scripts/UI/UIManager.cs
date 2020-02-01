using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    [SerializeField]
    private GameObject Player1;
    [SerializeField]
    private GameObject Player2;
    [SerializeField]
    private GameObject Player3;
    [SerializeField]
    private GameObject Player4;

    [SerializeField]
    private GameObject OpaqueScreen;
    [SerializeField]
    private GameObject Counter;
    [SerializeField]
    private GameObject TimerScore;
    private List<GameObject> mListPlayer = new List<GameObject>();

    [SerializeField]
    private List<Sprite> ListIcon = new List<Sprite>();

    private List<string> mListAction = new List<string>();

    private int mNbPlayer;

    private bool mCounterDone = false;
    
    [SerializeField]
    private float Timer;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        OpaqueScreen.SetActive(true);
        Counter.SetActive(true);
        Timer += 0.9F;
        mListPlayer.Add(Player1);
        mListPlayer.Add(Player2);
        mListPlayer.Add(Player3);
        mListPlayer.Add(Player4);
        mNbPlayer = GameManager.instance.usersN;

        if(GameManager.instance.gameMode.MODE == GameMode.GAMEMODE.G4COLLABSTACK)
        {
            for (int i = 0; i < GameManager.instance.usersN; ++i)
            {
                mListPlayer[i].GetComponentInChildren<Image>().color = GameManager.instance.users[i].color;
                for (int j = 0; j < ((GameMode.GCollabStack)GameManager.instance.gameMode).nbAction; ++j)
                {
                    mListAction.Add(((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name);
                    Debug.Log("Player " + i + " : " + ((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name);
                }
            }
        }
        
           // ((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions;
        //((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions;
    }

    // Update is called once per frame
    void Update()
    {
        if (!mCounterDone)
            Timer -= Time.deltaTime;

        if (Timer > 0 && !mCounterDone)
        {
            Counter.GetComponent<Text>().text = "" + (int)Timer;
        }
        else if (Timer < 0 && !mCounterDone)
        {
            mCounterDone = true;
            Counter.SetActive(false);
            OpaqueScreen.SetActive(false);

            TimerScore.SetActive(true);
            for (int i = 0; i < mNbPlayer; ++i)
                mListPlayer[i].SetActive(true);
        }
        ShowPlayerUI();

        TimerScore.GetComponent<Text>().text = GameManager.instance.time.ToString("F2");
    }

    private void ShowPlayerUI()
    {
        for (int i = 0; i < mNbPlayer; ++i)
        {
            int lIndice = i;
            lIndice++;
            mListPlayer[i].GetComponent<Text>().text = "Player" + lIndice + " " + GameManager.instance.users[i].action.name;
        }
    }
}