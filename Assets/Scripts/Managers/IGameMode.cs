using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameMode
{
    public abstract class IGameMode
    {
        public LevelManager.ILevelManager level = null;
        public abstract void changeAction(List<IUsersInput> users, ObjectMotionController obj);
        public abstract void changeAction(IUsersInput user, int d);
    }

    public class G2V2 : IGameMode
    {
        List<int> team1 = new List<int>();
        List<int> team2 = new List<int>();
        public override void changeAction(List<IUsersInput> users, ObjectMotionController obj)
        {
            foreach (IUsersInput user in users)
            {
                user.action.actionNull(obj);
                if (team1.Contains(user.nActual))
                {
                    user.action = level.actions2v2[Random.Range(0, (level.actions2v2.Count))];
                }
                else
                {
                    user.action = level.actions2v2[Random.Range(0, (level.actions2v2.Count))];
                }
            }
        }
        public override void changeAction(IUsersInput user, int d)
        {
            if (team1.Contains(user.nActual))
            {
                user.action = level.actions2v2[GameManager.mod(level.actions2v2.IndexOf(user.action) + d, level.actions2v2.Count)];
            }
            else
            {
                user.action = level.actions2v2[GameManager.mod(level.actions2v2.IndexOf(user.action) + d, level.actions2v2.Count)];
            }
        }
    }

    public class G3V1 : IGameMode
    {
        public int saboter;
        public override void changeAction(List<IUsersInput> users, ObjectMotionController obj)
        {
            foreach(IUsersInput user in users)
            {
                user.action.actionNull(obj);
                if (user.nActual == saboter)
                {
                    user.action = level.actions3v1[Random.Range(0, (level.actions3v1.Count))];
                }
                else
                {
                    user.action = level.actionsCollab[Random.Range(0, (level.actions3v1.Count))];
                }
            }
        }
        public override void changeAction(IUsersInput user, int d)
        {
            if(user.nActual == saboter)
            {
                user.action = level.actions3v1[GameManager.mod(level.actions3v1.IndexOf(user.action)+d,level.actions3v1.Count)];
            }
            else
            {
                user.action = level.actionsCollab[GameManager.mod(level.actionsCollab.IndexOf(user.action) + d, level.actionsCollab.Count)];
            }
        }
    }

    public class GCollab : IGameMode
    {
        public override void changeAction(List<IUsersInput> users, ObjectMotionController obj)
        {
            foreach (IUsersInput user in users)
            {
                user.action.actionNull(obj);
                user.action = level.actionsCollab[Random.Range(0, (level.actionsCollab.Count))];
            }
        }
        public override void changeAction(IUsersInput user, int d)
        {
            user.action = level.actionsCollab[GameManager.mod(level.actionsCollab.IndexOf(user.action) + d, level.actionsCollab.Count)];
        }
    }

    public class GCollabStack : IGameMode
    {
        public List<List<IActions>> nextActions;
        public override void changeAction(List<IUsersInput> users, ObjectMotionController obj)
        {
            foreach (IUsersInput user in users)
            {
                user.action.actionNull(obj);
                user.action = level.actionsCollab[Random.Range(0, (level.actionsCollab.Count))];
            }
        }
        public override void changeAction(IUsersInput user, int d)
        {
            user.action = level.actionsCollab[GameManager.mod(level.actionsCollab.IndexOf(user.action) + d, level.actionsCollab.Count)];
        }
    }
}
