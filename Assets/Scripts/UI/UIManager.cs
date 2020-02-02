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

    [SerializeField]
    private List<Sprite> ListButtonSprite = new List<Sprite>();

    private int mNbPlayer;

    private bool mCounterDone = false;
    
    [SerializeField]
    public float Timer;

    private Dictionary<string, Sprite> mDictionnaryIcon = new Dictionary<string, Sprite>();

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

        mDictionnaryIcon.Add("HorizontalAngle", ListIcon[1]);
        mDictionnaryIcon.Add("VerticalAngle", ListIcon[4]);
        mDictionnaryIcon.Add("OrientationYAngle", ListIcon[3]);
        mDictionnaryIcon.Add("OrientationXAngle", ListIcon[2]);
        mDictionnaryIcon.Add("Camera", ListIcon[5]);
        mDictionnaryIcon.Add("DepthAngle", ListIcon[0]);
        mDictionnaryIcon.Add("OrientationZAngle", ListIcon[6]);



        for (int i = 0; i < GameManager.instance.usersN; ++i)
        {
            mListPlayer[i].SetActive(true);
        }

        if (GameManager.instance.gameMode.MODE == GameMode.GAMEMODE.G4COLLABSTACK)
        {
            Debug.Log("1");
            for (int i = 0; i < GameManager.instance.usersN; ++i)
            {
                Debug.Log("2");
                mListPlayer[i].GetComponentInChildren<Image>().color = GameManager.instance.users[i].color;

                //Debug.Log("COLOR : " + GameManager.instance.users[i].color.ToString());
                for (int j = 0; j < ((GameMode.GCollabStack)GameManager.instance.gameMode).nbAction; j++)
                {
                    Debug.Log("3");
                    mListAction.Add(((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name);
                    //Debug.Log("lolololol : " + ((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name);
                    //Instantiate(mDictionnaryIcon[((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name], mListPlayer[i].transform.position + new Vector3(100F, 0F, 0F), Quaternion.identity, mListPlayer[i].transform);
                    if (i == 0)
                    {
                        Debug.Log("4");
                        if (j == 0)
                        {
                            Debug.Log("5");
                            PlayerOneBgOne.GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                            PlayerOneBgOne.transform.GetChild(0).GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                            PlayerOneBgOne.transform.GetChild(0).GetComponent<Image>().sprite = mDictionnaryIcon[((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name];
                        }
                        if(j == 1)
                        {
                            PlayerOneBgTwo.GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                            PlayerOneBgTwo.transform.GetChild(0).GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                            PlayerOneBgTwo.transform.GetChild(0).GetComponent<Image>().sprite = mDictionnaryIcon[((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name];
                        }

                        mListAction.Clear();
                    }
                    else if (i == 1)
                    {
                        if (j == 0)
                        {
                            PlayerTwoBgOne.GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);

                            PlayerTwoBgOne.transform.GetChild(0).GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                            PlayerTwoBgOne.transform.GetChild(0).GetComponent<Image>().sprite = mDictionnaryIcon[((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name];
                        }
                        if (j == 1)
                        {
                            PlayerTwoBgTwo.GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);

                            PlayerTwoBgTwo.transform.GetChild(0).GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                            PlayerTwoBgTwo.transform.GetChild(0).GetComponent<Image>().sprite = mDictionnaryIcon[((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name];
                        }
                        mListAction.Clear();
                    }
                    else if (i == 2)
                    {
                        if (j == 0)
                        {
                            PlayerThreeBgOne.GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);

                            PlayerThreeBgOne.transform.GetChild(0).GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                            PlayerThreeBgOne.transform.GetChild(0).GetComponent<Image>().sprite = mDictionnaryIcon[((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name];
                        }
                        if (j == 1)
                        {
                            PlayerThreeBgTwo.GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);

                            PlayerThreeBgTwo.transform.GetChild(0).GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                            PlayerThreeBgTwo.transform.GetChild(0).GetComponent<Image>().sprite = mDictionnaryIcon[((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name];
                        }
                        mListAction.Clear();
                    }
                    else if (i == 3)
                    {
                        if (j == 0)
                        {
                            PlayerFourBgOne.GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);

                            PlayerFourBgOne.transform.GetChild(0).GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                            PlayerFourBgOne.transform.GetChild(0).GetComponent<Image>().sprite = mDictionnaryIcon[((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name];
                        }
                        if (j == 1)
                        {
                            PlayerFourBgTwo.GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);

                            PlayerFourBgTwo.transform.GetChild(0).GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                            PlayerFourBgTwo.transform.GetChild(0).GetComponent<Image>().sprite = mDictionnaryIcon[((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name];
                        }
                        mListAction.Clear();
                    }

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
                    //Debug.Log(((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name);

                        mListAction.Add(((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name);
                        //Debug.Log("lolololol : " + ((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name);
                        //Instantiate(mDictionnaryIcon[((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name], mListPlayer[i].transform.position + new Vector3(100F, 0F, 0F), Quaternion.identity, mListPlayer[i].transform);
                        if (i == 0)
                        {
                            if (j == 0)
                            {
                            // PlayerOneBgOne.GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                            // PlayerOneBgOne.transform.GetChild(0).GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                            PlayerOneBgOne.transform.GetChild(0).GetComponent<Image>().sprite = mDictionnaryIcon[((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name];
                            }
                            if (j == 1)
                            {
                            // PlayerOneBgTwo.GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                            // PlayerOneBgTwo.transform.GetChild(0).GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                            PlayerOneBgTwo.transform.GetChild(0).GetComponent<Image>().sprite = mDictionnaryIcon[((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name];
                            }

                            mListAction.Clear();
                        }
                        else if (i == 1)
                        {
                            if (j == 0)
                            {
                                //PlayerTwoBgOne.GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                               // PlayerTwoBgOne.transform.GetChild(0).GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                                PlayerTwoBgOne.transform.GetChild(0).GetComponent<Image>().sprite = mDictionnaryIcon[((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name];
                            }
                            if (j == 1)
                            {
                                //PlayerTwoBgTwo.GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                                //PlayerTwoBgTwo.transform.GetChild(0).GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                                PlayerTwoBgTwo.transform.GetChild(0).GetComponent<Image>().sprite = mDictionnaryIcon[((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name];
                            }
                            mListAction.Clear();
                        }
                        else if (i == 2)
                        {
                            if (j == 0)
                            {
                                //PlayerThreeBgOne.GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                                //PlayerThreeBgOne.transform.GetChild(0).GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                                PlayerThreeBgOne.transform.GetChild(0).GetComponent<Image>().sprite = mDictionnaryIcon[((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name];
                            }
                            if (j == 1)
                            {
                                //PlayerThreeBgTwo.GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                               // PlayerThreeBgTwo.transform.GetChild(0).GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                                PlayerThreeBgTwo.transform.GetChild(0).GetComponent<Image>().sprite = mDictionnaryIcon[((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name];
                            }
                            mListAction.Clear();
                        }
                        else if (i == 3)
                        {
                            if (j == 0)
                            {
                                //PlayerFourBgOne.GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                                //PlayerFourBgOne.transform.GetChild(0).GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                                PlayerFourBgOne.transform.GetChild(0).GetComponent<Image>().sprite = mDictionnaryIcon[((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name];
                            }
                            if (j == 1)
                            {
                                //PlayerFourBgTwo.GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                               // PlayerFourBgTwo.transform.GetChild(0).GetComponent<Image>().color = new Color(1F, 1F, 1F, 1F);
                                PlayerFourBgTwo.transform.GetChild(0).GetComponent<Image>().sprite = mDictionnaryIcon[((GameMode.GCollabStack)GameManager.instance.gameMode).nextActions[i][j].name];
                            }
                            mListAction.Clear();
                        }
                    }
                    
            }
        }

        TimerScore.GetComponent<Text>().text = (GameManager.instance.time - GameManager.instance.timeStart).ToString("F2");
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

    private void ColorBG(GameObject iGo, Color iColor)
    {
        //Debug.Log("COLOR BG : " + iColor.r);
        //if (iColor.r > 0.9 && iColor.r <0.92)
        //{
        //    iGo.GetComponent<Image>().sprite = ListButtonSprite[0];
        //    Debug.Log("COLOR BG :  " + ListButtonSprite[0].ToString() + "  gameobject : "  + iGo.ToString());
        //}
        //else if (iColor.b > 0.6 && iColor.b < 0.65)
        //{
        //    iGo.GetComponent<Image>().sprite = ListButtonSprite[1];
        //    Debug.Log("COLOR BG :  " + ListButtonSprite[0].ToString() + "  gameobject : " + iGo.ToString());

        //}
        //else if (iColor.r > 0.85 && iColor.r < 0.88)
        //{
        //    iGo.GetComponent<Image>().sprite = ListButtonSprite[2];
        //    Debug.Log("COLOR BG :  " + ListButtonSprite[0].ToString() + "  gameobject : " + iGo.ToString());

        //}
        //else if (iColor.g > 0.55 && iColor.g < 0.59)
        //{
        //    iGo.GetComponent<Image>().sprite = ListButtonSprite[3];
        //    Debug.Log("COLOR BG :  " + ListButtonSprite[0].ToString() + "  gameobject : " + iGo.ToString());

        //}
    }

}