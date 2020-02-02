using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int mod(int x, int m)
    {
        return (x % m + m) % m;
    }

    [HideInInspector]
    public GameMode.IGameMode gameMode = null;
    [HideInInspector]
    public ActionChooser.IActionChooser actionChooser = null;
    [HideInInspector]
    public LevelManager.ILevelManager level = null;
    [HideInInspector]
    public EndCondition.IEndCondition endCondition = null;

    public GameMode.GAMEMODE mode = GameMode.GAMEMODE.G4COLLABSTACK;
    public EndCondition.ENDCONDITION condition = EndCondition.ENDCONDITION.POSOR;
    public ActionChooser.ACTIONCHOOSER chooser = ActionChooser.ACTIONCHOOSER.FREE;

    public List<IUsersInput> users = new List<IUsersInput>();

    public Transform targetTransform;

    public int usersN = 1;

    public static GameManager instance = null;

    public ObjectMotionController obj;
    public CameraMotionController objCam;
    public IndicationScript indicationScript;
    public Transform CameraWorkBench;
    public Transform MainCamera;
    public UIManager uiManager;
    public GameObject canvasPrefab;

    public float timeStart = 0f;
    public float time = 0f;
    private float timeF = 0f;

    public bool gameRunning = true;
    public bool gameFinished = false;

    public float counter = 3f;

    public List<GameObject> levels;
    public List<GameObject> Targets;
    public int levelN = 0;
    private GameObject prefab;
    private GameObject canvas;

    private bool sceneLoaded = false;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "WorkPlace")
        {
            objCam = Camera.main.GetComponent<CameraMotionController>();
            //canvas = GameObject.Instantiate(canvasPrefab);
            indicationScript = GameObject.FindGameObjectWithTag("Indication").GetComponent<IndicationScript>();
            uiManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIManager>();
            uiManager.gameObject.SetActive(false);
            startGame();
        }

    }

    public void killGame()
    {
        GameObject.Destroy(prefab);
        GameObject.Destroy(UIManager.instance.gameObject);
        UIManager.instance = null;
        //GameObject.Destroy(canvas);
        //canvas = null;
        //uiManager.gameObject.SetActive(false);
        prefab = null;
        gameFinished = false;
        gameRunning = false;
    }

    public void startGame()
    {
        gameRunning = true;
        prefab = GameObject.Instantiate(levels[levelN]);
        /*if(canvas == null)
        {
            canvas = GameObject.Instantiate(canvasPrefab);
        }*/
        uiManager.gameObject.SetActive(false);
        uiManager.gameObject.SetActive(true);
        uiManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIManager>();
        GameObject targetTransformG = GameObject.Instantiate(Targets[levelN]);
        targetTransform = targetTransformG.transform;
        //obj = GameObject.FindGameObjectWithTag("Object").GetComponent<ObjectMotionController>();
        obj = prefab.GetComponentInChildren<ObjectMotionController>();
        indicationScript.GetComponent<KeepPosition0>().target = obj.transform;
        objCam.CenterGameOject = obj.gameObject;

        timeStart = Time.timeSinceLevelLoad + counter + 1f;
        uiManager.gameObject.SetActive(true);
        uiManager.Timer = counter;
        for (int i = 0; i < usersN; ++i)
        {
            users[i].action = level.actionsCollab[0];
        }

        testLevel();
    }
    public void testLevel()
    {
        level = new LevelManager.Level1(indicationScript);
        gameMode = new GameMode.GCollabStack(level);
        gameMode.start();

        /*switch (mode)
        {
            case GameMode.GAMEMODE.G2V2:
                gameMode = new GameMode.G2V2(level);
                break;
            case GameMode.GAMEMODE.G3V1:
                gameMode = new GameMode.G3V1(level);
                break;
            case GameMode.GAMEMODE.G4COLLAB:
                gameMode = new GameMode.GCollab(level);
                break;
            case GameMode.GAMEMODE.G4COLLABSTACK:
                gameMode = new GameMode.GCollabStack(level);
                break;
            default:
                break;
        }
        gameMode.start();

        switch (chooser)
        {
            case ActionChooser.ACTIONCHOOSER.FREE:
                actionChooser = new ActionChooser.FreeActions();
                break;
            case ActionChooser.ACTIONCHOOSER.RANDOM:
                actionChooser = new ActionChooser.RandomActions();
                break;
        }

        switch (condition)
        {
            case EndCondition.ENDCONDITION.LASER:
                endCondition = new EndCondition.LaserFinish(GameObject.FindGameObjectsWithTag("LaserPath").ToList<GameObject>());
                break;
            case EndCondition.ENDCONDITION.POSOR:
                endCondition = new EndCondition.PositionOrientationFinish(targetTransform);
                break;
        }*/
        switch (levelN)
        {
            case 0:
                actionChooser = new ActionChooser.FreeActions();
                endCondition = new EndCondition.PositionFinish(targetTransform);
                break;
            case 1:
                actionChooser = new ActionChooser.RandomActions();
                endCondition = new EndCondition.PositionOrientationFinish(targetTransform);
                break;
        }
    }

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
            initSingleton();
        }

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a InputManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    void initSingleton()
    {
        testLevel();
        for (int i = 0; i < usersN; ++i)
        {
            users.Add(new IUsersInput());
            users[i].action = level.actionsCollab[0];
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void inputActions()
    {
        if (obj == null)
            return;
        
        obj.velocity = Vector3.zero;
        obj.rotation = Vector3.zero;
        foreach (IUsersInput user in users)
        {
//            Debug.Log(user.prefix + "  " + user.GetHorizontal() + "  " + user.GetVertical() + "  " + user.GetRT() + "  " + user.GetLT());
            if (user.GetLT() > 0.5f && user.triggerLT == false)
            {
                user.action.actionNull(user, obj);
                actionChooser.chooseAction(user, 1, gameMode);
                user.triggerLT = true;
            }
            else if (user.GetLT() <= 0f)
            {
                user.triggerLT = false;
            }
            //Debug.Log("Trigger_RT " + Input.GetAxis(user.prefix + "Trigger_RT"));
            if (user.GetRT() > 0.5f && user.triggerRT == false)
            {
                user.action.actionNull(user, obj);
                actionChooser.chooseAction(user, -1, gameMode);
                user.triggerRT = true;
            }
            else if (user.GetRT() <= 0f)
            {
                user.triggerRT = false;
            }
            if (user.action != null)
                user.act(obj, objCam);
        }

        foreach(IActions action in level.actionsCollab)
        {
            bool inUsers = false;
            foreach(IUsersInput user in users)
            {
                if (action == user.action)
                    inUsers = true;
            }
            foreach (IUsersInput user in users)
            {
                if (!inUsers)
                    action.actionNull(user, obj);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        time = Time.timeSinceLevelLoad;
        if (gameRunning)
        {
            if(time - timeStart >= 0f)
            {
                inputActions();
                if(obj != null)
                {
                    actionChooser.chooseAction(time, users, gameMode, obj);
                    endCondition.update(obj);
                    if (endCondition.isFinished(obj))
                    {
                        gameRunning = false;
                        gameFinished = true;
                        foreach (IUsersInput user in users)
                        {
                            user.action.actionNull(user, obj);
                            user.action = null;
                        }
                        timeF = 0f;
                    }
                }
            }
        }
        if (gameFinished)
        {
            timeF += Time.deltaTime;
            endCondition.end(obj, time);
            if(timeF > 5f)
            {
                levelN++;
                //killGame();
                //startGame();
                killGame();
                SceneManager.LoadScene("WorkPlace");
            }
        }
    }
}
