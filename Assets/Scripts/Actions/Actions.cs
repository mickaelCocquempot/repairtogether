using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actions
{
    public class HorizontalAction : IActions
    {
        public HorizontalAction()
        {
            name = "Horizontal";
        }
        public override void actionNull(ObjectMotionController obj)
        {
            obj.velocity.x = 0;
        }
        public override void action(string prefix, ObjectMotionController obj)
        {
            obj.velocity.x = Input.GetAxis(prefix + "Horizontal");
        }
    }

    public class VerticalAction : IActions
    {
        public VerticalAction()
        {
            name = "Vertical";
        }
        public override void actionNull(ObjectMotionController obj)
        {
            obj.velocity.y = 0;
        }
        public override void action(string prefix, ObjectMotionController obj)
        {
            obj.velocity.y = -Input.GetAxis(prefix + "Vertical");
        }
    }

    public class OrientationXAction : IActions
    {
        public OrientationXAction()
        {
            name = "OrientationX";
        }
        public override void actionNull(ObjectMotionController obj)
        {
            obj.rotation.x = 0;
        }
        public override void action(string prefix, ObjectMotionController obj)
        {
            obj.rotation.x = Input.GetAxis(prefix + "Vertical");
        }
    }

    public class OrientationYAction : IActions
    {
        public OrientationYAction()
        {
            name = "OrientationY";
        }
        public override void actionNull(ObjectMotionController obj)
        {
            obj.rotation.y = 0;
        }
        public override void action(string prefix, ObjectMotionController obj)
        {
            obj.rotation.y = Input.GetAxis(prefix + "Horizontal"); 
        }
    }

    public class CameraAction : IActions
    {
        public CameraAction()
        {
            name = "Camera";
        }
        public override void actionNull(ObjectMotionController obj)
        {

        }
        public override void actionCam(string prefix, CameraMotionController obj)
        {
            obj.MoveDown(Input.GetAxis(prefix + "Vertical"));
            obj.MoveRight(Input.GetAxis(prefix + "Horizontal"));
        }
    }
}
