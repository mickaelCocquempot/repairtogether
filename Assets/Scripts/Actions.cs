using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actions
{
    public class HorizontalAction : IActions
    {
        public override void action(string prefix, ObjectMotionController obj)
        {
            Debug.Log("Horizontal");
            obj.velocity.x = Input.GetAxis(prefix + "Horizontal");
        }
    }

    public class VerticalAction : IActions
    {
        public override void action(string prefix, ObjectMotionController obj)
        {
            Debug.Log("Vert");
            obj.velocity.y = -Input.GetAxis(prefix + "Vertical");
        }
    }

    public class OrientationXAction : IActions
    {
        public override void action(string prefix, ObjectMotionController obj)
        {
            Debug.Log("OrientationX");
            obj.rotation.x = Input.GetAxis(prefix + "Vertical");
        }
    }

    public class OrientationYAction : IActions
    {
        public override void action(string prefix, ObjectMotionController obj)
        {
            Debug.Log("OrientationY");
            obj.rotation.y = Input.GetAxis(prefix + "Horizontal"); 
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
