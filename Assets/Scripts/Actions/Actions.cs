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
            obj.velocity.x += input.GetHorizontal() * input.speed;
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
            obj.velocity.y += -input.GetVertical() * input.speed;
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
            obj.velocity.z += -input.GetVertical() * input.speed;
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
            obj.rotation.x += input.GetVertical() * input.speed;
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
            obj.rotation.y += input.GetVertical() * input.speed; 
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
            obj.MoveDown(input.GetVertical()*input.speed);
            obj.MoveRight(input.GetHorizontal() * input.speed);
        }
    }

    public class AngleAction : IActions
    {
        protected List<float> angles = new List<float>();
        public AngleAction()
        {
            angles.Add(0f);
            angles.Add(0f);
            angles.Add(0f);
            angles.Add(0f);
        }
        public AngleAction(string n)
        {
            angles.Add(0f);
            angles.Add(0f);
            angles.Add(0f);
            angles.Add(0f);
            name = n;
        }
        protected float dv(IUsersInput input)
        {
            float dv = Mathf.Sin(angles[input.nActual - 1] - Mathf.Atan2(input.GetVertical(), input.GetHorizontal()))*input.speed;
            angles[input.nActual - 1] = Mathf.Atan2(input.GetVertical(), input.GetHorizontal());
            return dv;
        }
        public override void actionNull(ObjectMotionController obj)
        {

        }

        public override void action(IUsersInput input, ObjectMotionController obj)
        {
            float dv = Mathf.Sin(angles[input.nActual-1] - Mathf.Atan2(input.GetVertical(), input.GetHorizontal())) * input.speed;
            angles[input.nActual-1] = Mathf.Atan2(input.GetVertical(), input.GetHorizontal());
            obj.velocity.x += dv;
        }
    }

    public class HorizontalAngleAction : AngleAction
    {
        public HorizontalAngleAction() : base("HorizontalAngle")
        {
        }
        public override void action(IUsersInput input, ObjectMotionController obj)
        {
            obj.velocity.x += dv(input);
        }
    }

    public class VerticalAngleAction : AngleAction
    {
        public VerticalAngleAction() : base("VerticalAngle")
        {
        }
        public override void action(IUsersInput input, ObjectMotionController obj)
        {
            obj.velocity.y += dv(input);
        }
    }

    public class OrientationXAngleAction : AngleAction
    {
        public OrientationXAngleAction() : base("OrientationXAngle")
        {
        }
        public override void action(IUsersInput input, ObjectMotionController obj)
        {
            obj.rotation.x += dv(input);
        }
    }

    public class OrientationYAngleAction : AngleAction
    {
        public OrientationYAngleAction() : base("OrientationYAngle")
        {
        }
        public override void action(IUsersInput input, ObjectMotionController obj)
        {
            obj.rotation.y += dv(input);
        }
    }

    public class DepthAngleAction : AngleAction
    {
        public DepthAngleAction() : base("DepthAngle")
        {
        }
        public override void action(IUsersInput input, ObjectMotionController obj)
        {
            obj.velocity.z += dv(input);
        }
    }
}
