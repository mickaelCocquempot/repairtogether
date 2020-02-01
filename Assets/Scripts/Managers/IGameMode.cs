using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameMode
{
    public enum GAMEMODE { G2V2, G3V1, G4COLLAB, G4COLLABSTACK};
    public abstract class IGameMode
    {
        public GAMEMODE MODE;
        public LevelManager.ILevelManager level = null;
        public IGameMode(LevelManager.ILevelManager level)
        {
            this.level = level;
        }

        public delegate void eventChangeAll();
        public delegate void eventChange(IUsersInput user);

        public eventChange eventC;
        public eventChangeAll eventCAll;

        public abstract void start();
        public abstract void changeAction(List<IUsersInput> users, ObjectMotionController obj);
        public abstract void changeAction(IUsersInput user, int d);
    }

    public class G2V2 : IGameMode
    {
        List<int> team1 = new List<int>();
        List<int> team2 = new List<int>();

        public G2V2(LevelManager.ILevelManager level) : base(level)
        {
            MODE = GAMEMODE.G2V2;
        }

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
            eventCAll();
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
            eventC(user);
        }

        public override void start()
        {
        }
    }

    public class G3V1 : IGameMode
    {
        public int saboter;

        public G3V1(LevelManager.ILevelManager level) : base(level)
        {
            MODE = GAMEMODE.G3V1;
        }
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
            eventCAll();
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
            eventC(user);
        }

        public override void start()
        {
        }
    }

    public class GCollab : IGameMode
    {
        public GCollab(LevelManager.ILevelManager level) : base(level)
        {
            MODE = GAMEMODE.G4COLLAB;
        }
        public override void changeAction(List<IUsersInput> users, ObjectMotionController obj)
        {
            foreach (IUsersInput user in users)
            {
                user.action.actionNull(obj);
                user.action = level.actionsCollab[Random.Range(0, (level.actionsCollab.Count))];
            }
            eventCAll();
        }
        public override void changeAction(IUsersInput user, int d)
        {
            user.action = level.actionsCollab[GameManager.mod(level.actionsCollab.IndexOf(user.action) + d, level.actionsCollab.Count)];
            eventC(user);
        }

        public override void start()
        {
        }
    }

    public class GCollabStack : IGameMode
    {
        public int nbAction = 2;
        public List<List<IActions>> nextActions = new List<List<IActions>>();

        public GCollabStack(LevelManager.ILevelManager level) : base(level)
        {
            MODE = GAMEMODE.G4COLLABSTACK;
        }

        public override void changeAction(List<IUsersInput> users, ObjectMotionController obj)
        {
            foreach(IUsersInput user in users)
            {
                user.action = nextActions[user.nActual-1][0];
                nextActions[user.nActual-1].RemoveAt(0);
                nextActions[user.nActual-1].Add(level.actionsCollab[Random.Range(0, (level.actionsCollab.Count))]);
            }
            eventCAll();
        }
        public override void changeAction(IUsersInput user, int d)
        {
            user.action = nextActions[user.nActual-1][0];
            nextActions[user.nActual-1].RemoveAt(0);
            nextActions[user.nActual-1].Add(level.actionsCollab[Random.Range(0, (level.actionsCollab.Count))]);
            eventC(user);
        }

        public override void start()
        {
            for (int i = 0; i < 4; i++) {
                List<IActions> actions = new List<IActions>();
                for (int j = 0; j < 2; j++)
                    actions.Add(level.actionsCollab[Random.Range(0, (level.actionsCollab.Count))]);
                nextActions.Add(actions);
            }
        }
    }
}
