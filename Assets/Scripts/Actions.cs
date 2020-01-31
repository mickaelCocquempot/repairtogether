using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actions
{
    public class HorizontalAction : IActions
    {
        public override void action(string prefix, ObjectMotionController obj)
        {
            //obj.setmotion...
            Debug.Log(Input.GetAxis(prefix + "Horizontal"));
        }
    }

    public class VerticalAction : IActions
    {
        public override void action(string prefix, ObjectMotionController obj)
        {
            //obj
            //obj.setmotion...
            Debug.Log(Input.GetAxis(prefix + "Horizontal"));
        }
    }

    public class CameraAction : IActions
    {
        public override void action(string prefix, ObjectMotionController obj)
        {
            //obj.setmotion...
            Debug.Log(Input.GetAxis(prefix + "Vertical"));
            Debug.Log(Input.GetAxis(prefix + "Horizontal"));
        }
    }
}
