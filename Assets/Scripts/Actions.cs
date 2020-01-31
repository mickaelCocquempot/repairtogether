using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actions
{
    public class HorizontalAction : IActions
    {
        public override void action(string prefix, ObjectMotionController obj)
        {
            Debug.Log("Horizontal " + Input.GetAxisRaw(prefix + "Horizontal"));
            obj.velocity.x = Input.GetAxisRaw(prefix + "Horizontal");
        }
    }

    public class VerticalAction : IActions
    {
        public override void action(string prefix, ObjectMotionController obj)
        {
            obj.velocity.y = Input.GetAxisRaw(prefix + "Vertical");
        }
    }

    public class OrientationXAction : IActions
    {
        public override void action(string prefix, ObjectMotionController obj)
        {
            obj.rotation.x = Input.GetAxisRaw(prefix + "Horizontal");
        }
    }

    public class OrientationYAction : IActions
    {
        public override void action(string prefix, ObjectMotionController obj)
        {
            obj.rotation.y = Input.GetAxisRaw(prefix + "Vertical");
        }
    }

    public class CameraAction : IActions
    {
        public override void action(string prefix, ObjectMotionController obj)
        {
            Debug.Log(Input.GetAxis(prefix + "Vertical"));
            Debug.Log(Input.GetAxis(prefix + "Horizontal"));
        }
    }
}
