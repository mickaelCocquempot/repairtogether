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
    private List<GameObject> ListIcon = new List<GameObject>();

    private List<string> mListAction = new List<string>();

    [SerializeField]
    private GameObject PlayerOneBgOne;
    [SerializeField]
    private GameObject PlayerOneBgTwo;

    [SerializeField]
    private GameObject PlayerTwoBgOne;
    [SerializeField]
    private GameObject PlayerTwoBgTwo;

    [SerializeField]
    private GameObject PlayerThreeBgOne;
    [SerializeField]
    private GameObject PlayerThreeBgTwo;

    [SerializeField]
    private GameObject PlayerFourBgOne;
    [SerializeField]
    private GameObject PlayerFourBgTwo;

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
        Dictionary<string, GameObject> mDictionnaryIcon = new Dictionary<string, GameObject>();
        OpaqueScreen.SetActive(true);
        Counter.SetActive(true);
        Timer += 0.9F;
        mListPlayer.Add(Player1);
        mListPlayer.Add(Player2);
        mListPlayer.Add(Player3);
        mListPlayer.Add(Player4);
        mNbPlayer = GameManager.instance.usersN;

        mDictionnaryIcon.Add("Horizontal", ListIcon[1]);
        mDictionnaryIcon.Add("Vertical", ListIcon[4]);
        mDictionnaryIcon.Add("OrientationY", ListIcon[3]);
        mDictionnaryIcon.Add("OrientationX", ListIcon[2]);
        mDictionnaryIcon.Add("Camera", ListIcon[5]);
        mDictionnaryIcon.Add("Depth", ListIcon[0]);


        for (int i = 0; i < GameManager.instance.usersN; ++i)
        {
            mListPlayer[i].SetActive(true);
        }

        if (GameManager.instance.gameMode.MODE == GameMode.GAMEMODE.G4COLLABSTACK)
        {
            for (int i = 0; i < GameManager.instance.usersN; ++i)
            {
                if(i == 0)

                mListPlayer[i].GetComponentInChildren<Image>().color = GameManager.instance.users[i].color;
                Debug.Log(GameManager.instance.users[i].color.ToString());
                for (int j = 0; j < ((GameMode.GCollabStack)GameManager.instance.gameMode).nbAction; ++j)
                {

                    mListAction.Add(((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name);
                    //Instantiate(mDictionnaryIcon[((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name], mListPlayer[i].transform.position + new Vector3(100F, 0F, 0F), Quaternion.identity, mListPlayer[i].transform);
                    if(i == 0)
                    {
                        PlayerOneBgOne.GetComponentInChildren<SpriteRenderer>().sprite = mDictionnaryIcon[((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name].GetComponent<SpriteRenderer>().sprite;
                        PlayerOneBgTwo.GetComponentInChildren<SpriteRenderer>().sprite = mDictionnaryIcon[((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name].GetComponent<SpriteRenderer>().sprite;
                        Debug.Log(mDictionnaryIcon[((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name].GetComponent<SpriteRenderer>().sprite.ToString());
                    }
                    Debug.Log(mDictionnaryIcon[((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name].ToString());
                    //Debug.LogWarning("Player " + i + " : " + ((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name);
                }
            }
        }
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

        if(GameManager.instance.gameMode.MODE == GameMode.GAMEMODE.G4COLLAB)
            ShowPlayerUI();
        if (GameManager.instance.gameMode.MODE == GameMode.GAMEMODE.G4COLLABSTACK)
        {
            for (int i = 0; i < GameManager.instance.usersN; ++i)
            {
                for (int j = 0; j < ((GameMode.GCollabStack)GameManager.instance.gameMode).nbAction; ++j)
                {
                    mListAction.Add(((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name);
                    Debug.Log(((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name);
                }
            }
        }

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