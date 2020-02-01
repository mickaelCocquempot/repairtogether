using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int mod(int x, int m)
    {
        return (x % m + m) % m;
    }

    GameMode.IGameMode gameMode = null;
    ActionChooser.IActionChooser actionChooser = null;
    LevelManager.ILevelManager level = null;

    public List<IUsersInput> users = new List<IUsersInput>();

    public Transform targetTransform;

    public int usersN = 1;

    public static GameManager instance = null;

    public ObjectMotionController obj;
    public CameraMotionController objCam;

    public float time = 0f;
    private float timeF = 0f;

    public bool gameRunning = true;
    public bool gameFinished = false;

    public void testLevel()
    {
        level = new LevelManager.Level1();
        gameMode = new GameMode.GCollab();
        gameMode.level = level;
        actionChooser = new ActionChooser.FreeActions();
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
    }

    private void inputActions()
    {
        foreach (IUsersInput user in users)
        {
            //Debug.Log("Trigger_LT " + Input.GetAxis(user.prefix + "Trigger_LT"));
            if (user.GetLT() > 0.5f && user.triggerLT == false)
            {
                user.action.actionNull(obj);
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
                user.action.actionNull(obj);
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
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.timeSinceLevelLoad;
        if (gameRunning)
        {
            inputActions();
            actionChooser.chooseAction(time, users, gameMode, obj);

            //Debug.Log(Vector3.Distance(targetTransform.position, obj.transform.position));
            //Debug.Log(Quaternion.Angle(targetTransform.rotation, obj.transform.rotation));
            if (Vector3.Distance(targetTransform.position, obj.transform.position) < 0.3f && Quaternion.Angle(targetTransform.rotation, obj.transform.rotation) < 5f)
            {
                gameRunning = false;
                gameFinished = true;
                foreach (IUsersInput user in users)
                {
                    user.action.actionNull(obj);
                    user.action = null;
                }
            }
        }
        if (gameFinished)
        {
            timeF += Time.deltaTime;
            obj.GetComponent<Collider>().enabled = false;
            Debug.Log(timeF / 10.0f);
            obj.transform.position = Vector3.Lerp(obj.transform.position, targetTransform.position, timeF/10.0f);
            obj.transform.rotation = Quaternion.Lerp(obj.transform.rotation, targetTransform.rotation, timeF / 10.0f);
        }
    }
}
