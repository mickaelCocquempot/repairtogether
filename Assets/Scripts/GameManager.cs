using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<IActions> actions = new List<IActions>();
    public List<IUsersInput> users = new List<IUsersInput>();

    public int usersN = 1;

    GameObject instance = null;

    public ObjectMotionController obj;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this.gameObject;
            initSingleton();
        }


        //If instance already exists and it's not this:
        else if (instance != this.gameObject)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a InputManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    void initSingleton()
    {
        actions.Add(new Actions.HorizontalAction());
        actions.Add(new Actions.VerticalAction());
        actions.Add(new Actions.OrientationXAction());
        actions.Add(new Actions.OrientationYAction());
        actions.Add(new Actions.CameraAction());
        for (int i = 0; i < usersN; ++i)
        {
            addPlayer();
        }
    }

    public void setAction(IActions action, int nUser)
    {
        if(nUser <= usersN)
        {
            users[nUser].action = action;
        }
    }

    public void addPlayer()
    {
        users.Add(new IUsersInput());
    }

    int mod(int x, int m)
    {
        return (x % m + m) % m;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (IUsersInput user in users)
        {
            //Debug.Log("Trigger_LT " + Input.GetAxis(user.prefix + "Trigger_LT"));
            if (Input.GetAxis(user.prefix + "Trigger_LT") > 0.5f && user.triggerLT == false)
            {
                user.action = actions[mod(actions.IndexOf(user.action) + 1, actions.Count)];
                user.triggerLT = true;
            }
            else if (Input.GetAxis(user.prefix + "Trigger_LT") <= 0f)
            {
                user.triggerLT = false;
            }
            //Debug.Log("Trigger_RT " + Input.GetAxis(user.prefix + "Trigger_RT"));
            if (Input.GetAxis(user.prefix + "Trigger_RT") > 0.5f && user.triggerRT == false)
            {
                user.action = actions[mod(actions.IndexOf(user.action) - 1, actions.Count)];
                user.triggerRT = true;
            }
            else if (Input.GetAxis(user.prefix + "Trigger_RT") <= 0f)
            {
                user.triggerRT = false;
            }
            if (user.action != null)
                user.act(obj);
        }
    }
}
