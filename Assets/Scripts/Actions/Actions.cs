using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actions
{
    public class HorizontalAction : IActions
    {
        public HorizontalAction(IndicationScript indication) : base(indication)
        {
            name = "Horizontal";
        }
        public override void actionNull(IUsersInput input, ObjectMotionController obj)
        {
            if(indicationScript != null)
                indicationScript.disableLeftRight(input);
            obj.velocity.x = 0;
        }
        public override void action(IUsersInput input, ObjectMotionController obj)
        {
            if (indicationScript != null)
                indicationScript.enableLeftRight(input, input.GetHorizontal());
            obj.velocity.x += input.GetHorizontal() * input.speed;
        }
    }

    public class VerticalAction : IActions
    {
        public VerticalAction(IndicationScript indication) : base(indication)
        {
            name = "Vertical";
        }
        public override void actionNull(IUsersInput input, ObjectMotionController obj)
        {
            if (indicationScript != null)
                indicationScript.disableUpDown(input);
            obj.velocity.y = 0;
        }
        public override void action(IUsersInput input, ObjectMotionController obj)
        {
            if (indicationScript != null)
                indicationScript.enableUpDown(input, -input.GetVertical());
            obj.velocity.y += -input.GetVertical() * input.speed;
        }
    }

    public class DepthAction : IActions
    {
        public DepthAction(IndicationScript indication) : base(indication)
        {
            name = "Depth";
        }
        public override void actionNull(IUsersInput input, ObjectMotionController obj)
        {
            if (indicationScript != null)
                indicationScript.disableFrontBack(input);
            obj.velocity.z = 0;
        }
        public override void action(IUsersInput input, ObjectMotionController obj)
        {
            if (indicationScript != null)
                indicationScript.enableFrontBack(input, -input.GetVertical());
            obj.velocity.z += -input.GetVertical() * input.speed;
        }
    }

    public class OrientationXAction : IActions
    {
        public OrientationXAction(IndicationScript indication) : base(indication)
        {
            name = "OrientationX";
        }
        public override void actionNull(IUsersInput input, ObjectMotionController obj)
        {

            if (indicationScript != null)
                indicationScript.disableOrX(input);
            obj.rotation.x = 0;
        }
        public override void action(IUsersInput input, ObjectMotionController obj)
        {
            if (indicationScript != null)
                indicationScript.enableOrX(input, input.GetVertical() * input.speed);
            obj.rotation.x += input.GetVertical() * input.speed;
        }
    }

    public class OrientationYAction : IActions
    {
        public OrientationYAction(IndicationScript indication) : base(indication)
        {
            name = "OrientationY";
        }
        public override void actionNull(IUsersInput input, ObjectMotionController obj)
        {
            if (indicationScript != null)
                indicationScript.disableOrY(input);
            obj.rotation.z = 0;
        }
        public override void action(IUsersInput input, ObjectMotionController obj)
        {
            if (indicationScript != null)
                indicationScript.enableOrY(input, input.GetVertical() * input.speed);
            obj.rotation.z += input.GetVertical() * input.speed; 
        }
    }

    public class CameraAction : IActions
    {
        public CameraAction(IndicationScript indication) : base(indication)
        {
            name = "Camera";
        }
        public override void actionNull(IUsersInput input, ObjectMotionController obj)
        {

        }
        public override void actionCam(IUsersInput input, CameraMotionController obj)
        {
            obj.MoveDistanceFromObject(input.GetButtonX() - input.GetButtonY());
            obj.MoveDown(input.GetVertical()*input.speed);
            obj.MoveRight(input.GetHorizontal() * input.speed);
        }
    }

    public class AngleAction : IActions
    {
        protected List<float> angles = new List<float>();
        public AngleAction(IndicationScript indication) : base(indication)
        {
            angles.Add(0f);
            angles.Add(0f);
            angles.Add(0f);
            angles.Add(0f);
        }
        public AngleAction(IndicationScript indication, string n) : base(indication)
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
        public override void actionNull(IUsersInput input, ObjectMotionController obj)
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
        public HorizontalAngleAction(IndicationScript indication) : base(indication, "HorizontalAngle")
        {
        }
        public override void actionNull(IUsersInput input, ObjectMotionController obj)
        {
            if (indicationScript != null)
                indicationScript.disableLeftRight(input);
            obj.velocity.x = 0;
        }
        public override void action(IUsersInput input, ObjectMotionController obj)
        {
            float dvv = dv(input);
            if (indicationScript != null)
                indicationScript.enableLeftRight(input, dvv);
            obj.velocity.x += dvv;
        }
    }

    public class VerticalAngleAction : AngleAction
    {
        public VerticalAngleAction(IndicationScript indication) : base(indication, "VerticalAngle")
        {
        }
        public override void actionNull(IUsersInput input, ObjectMotionController obj)
        {
            if (indicationScript != null)
                indicationScript.disableUpDown(input);
            obj.velocity.y = 0;
        }
        public override void action(IUsersInput input, ObjectMotionController obj)
        {
            float dvv = dv(input);
            if (indicationScript != null)
                indicationScript.enableUpDown(input, dvv);
            obj.velocity.y += dvv;
        }
    }

    public class OrientationXAngleAction : AngleAction
    {
        public OrientationXAngleAction(IndicationScript indication) : base(indication, "OrientationXAngle")
        {
        }
        public override void actionNull(IUsersInput input, ObjectMotionController obj)
        {
            if (indicationScript != null)
                indicationScript.disableOrX(input);
            obj.rotation.x = 0;
        }
        public override void action(IUsersInput input, ObjectMotionController obj)
        {
            float dvv = dv(input);
            if (indicationScript != null)
                indicationScript.enableOrX(input, dvv);
            obj.rotation.x += dvv;
        }
    }

    public class OrientationYAngleAction : AngleAction
    {
        public OrientationYAngleAction(IndicationScript indication) : base(indication, "OrientationYAngle")
        {
        }
        public override void actionNull(IUsersInput input, ObjectMotionController obj)
        {
            if (indicationScript != null)
                indicationScript.disableOrY(input);
            obj.rotation.z = 0;
        }
        public override void action(IUsersInput input, ObjectMotionController obj)
        {
            float dvv = dv(input);
            if (indicationScript != null)
                indicationScript.enableOrY(input, dvv);
            obj.rotation.z += dvv;
        }
    }

    public class DepthAngleAction : AngleAction
    {
        public DepthAngleAction(IndicationScript indication) : base(indication, "DepthAngle")
        {
        }
        public override void actionNull(IUsersInput input, ObjectMotionController obj)
        {
            if (indicationScript != null)
                indicationScript.disableFrontBack(input);
            //obj.velocity.z = 0;
        }
        public override void action(IUsersInput input, ObjectMotionController obj)
        {
            float dvv = dv(input);
            if (indicationScript != null)
                indicationScript.enableFrontBack(input, dvv);
            obj.velocity.z += dvv;
        }
    }
}
