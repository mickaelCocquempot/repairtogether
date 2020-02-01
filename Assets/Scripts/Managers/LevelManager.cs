using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManager
{
    public class ILevelManager
    {
        public List<IActions> actionsCollab = null;
        public List<IActions> actions2v2 = null;
        public List<IActions> actions3v1 = null;
    }

    public class Level1 : ILevelManager
    {
        public Level1()
        {
            actionsCollab = new List<IActions>() { new Actions.HorizontalAction(), new Actions.VerticalAction(), new Actions.OrientationXAction(), new Actions.OrientationYAction(), new Actions.CameraAction()};
            actions2v2 = new List<IActions>() { new Actions.HorizontalAction(), new Actions.VerticalAction(), new Actions.OrientationXAction(), new Actions.OrientationYAction(), new Actions.CameraAction() };
            actions3v1 = new List<IActions>() { new Actions.HorizontalAction(), new Actions.VerticalAction(), new Actions.OrientationXAction(), new Actions.OrientationYAction(), new Actions.CameraAction() };
        }
    }
}
