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
        public override void action(IUsersInput input, ObjectMotionController obj)
        {
            obj.velocity.x = input.GetHorizontal();
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
        public override void action(IUsersInput input, ObjectMotionController obj)
        {
            obj.velocity.y = -input.GetVertical();
        }
    }

    public class DepthAction : IActions
    {
        public DepthAction()
        {
            name = "Depth";
        }
        public override void actionNull(ObjectMotionController obj)
        {
            obj.velocity.z = 0;
        }
        public override void action(IUsersInput input, ObjectMotionController obj)
        {
            obj.velocity.z = -input.GetVertical();
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
        public override void action(IUsersInput input, ObjectMotionController obj)
        {
            obj.rotation.x = input.GetVertical();
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
        public override void action(IUsersInput input, ObjectMotionController obj)
        {
            obj.rotation.y = input.GetVertical(); 
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
        public override void actionCam(IUsersInput input, CameraMotionController obj)
        {
            obj.MoveDown(input.GetVertical());
            obj.MoveRight(input.GetHorizontal());
        }
    }
}
