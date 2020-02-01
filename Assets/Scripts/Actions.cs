using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actions
{
    public class HorizontalAction : IActions
    {
        public override void action(string prefix, ObjectMotionController obj)
        {
            obj.velocity.x = Input.GetAxis(prefix + "Horizontal");
        }
    }

    public class VerticalAction : IActions
    {
        public override void action(string prefix, ObjectMotionController obj)
        {
            obj.velocity.y = -Input.GetAxis(prefix + "Vertical");
        }
    }

    public class OrientationXAction : IActions
    {
        public override void action(string prefix, ObjectMotionController obj)
        {
            obj.rotation.x = Input.GetAxis(prefix + "Vertical");
        }
    }

    public class OrientationYAction : IActions
    {
        public override void action(string prefix, ObjectMotionController obj)
        {
            obj.rotation.y = Input.GetAxis(prefix + "Horizontal"); 
        }
    }

    public class CameraAction : IActions
    {
        public override void actionCam(string prefix, CameraMotionController obj)
        {
            obj.MoveDown(Input.GetAxis(prefix + "Vertical"));
            obj.MoveRight(Input.GetAxis(prefix + "Horizontal"));
        }
    }
}
