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
        public Level1(IndicationScript ind)
        {
            actionsCollab = new List<IActions>() { new Actions.HorizontalAngleAction(ind), new Actions.VerticalAngleAction(ind), new Actions.OrientationXAngleAction(ind), new Actions.OrientationYAngleAction(ind), new Actions.DepthAngleAction(ind), new Actions.CameraAction(ind)};
            actions2v2 = new List<IActions>() { new Actions.HorizontalAction(ind), new Actions.VerticalAction(ind), new Actions.OrientationXAction(ind), new Actions.OrientationYAction(ind), new Actions.CameraAction(ind) };
            actions3v1 = new List<IActions>() { new Actions.HorizontalAction(ind), new Actions.VerticalAction(ind), new Actions.OrientationXAction(ind), new Actions.OrientationYAction(ind), new Actions.CameraAction(ind) };
        }
    }
}
