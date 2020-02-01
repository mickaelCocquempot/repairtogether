﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActionChooser
{
    public enum ACTIONCHOOSER { FREE, RANDOM}
    public abstract class IActionChooser
    {
        public abstract void chooseAction(IUsersInput user, int d, GameMode.IGameMode gameMode);
        public abstract void chooseAction(float time, List<IUsersInput> users, GameMode.IGameMode gameMode, ObjectMotionController obj);
    }

    public class FreeActions : IActionChooser
    {
        public override void chooseAction(IUsersInput user, int d, GameMode.IGameMode gameMode)
        {
            gameMode.changeAction(user, d);
        }
        public override void chooseAction(float time, List<IUsersInput> users, GameMode.IGameMode gameMode, ObjectMotionController obj)
        {

        }
    }

    public class RandomActions : IActionChooser
    {
        public override void chooseAction(IUsersInput user, int d, GameMode.IGameMode gameMode)
        {

        }
        public override void chooseAction(float time, List<IUsersInput> users, GameMode.IGameMode gameMode, ObjectMotionController obj)
        {
            if(time%5f < 0.5f)
            {
                gameMode.changeAction(users, obj);
            }
        }
    }
}
