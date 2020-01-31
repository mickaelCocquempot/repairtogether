using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<IActions> actions = new List<IActions>();
    public List<IUsersInput> users = new List<IUsersInput>();

    public int usersN = 1;

    void Start()
    {
        actions.Add(new HorizontalAction());
        for(int i = 0; i < usersN; ++i)
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

    // Update is called once per frame
    void Update()
    {
        foreach (IUsersInput user in users)
        {
            if(Input.GetAxis(user.prefix + "Trigger_LT") > 0.5f)
            {
                user.action = actions[(actions.IndexOf(user.action) + 1) % actions.Count];
            }
            else
            {
                user.action = actions[(actions.IndexOf(user.action) - 1) % actions.Count];
            }
            user.act();
        }
    }
}
