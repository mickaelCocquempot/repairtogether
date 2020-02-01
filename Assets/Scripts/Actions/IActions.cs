using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IActions
{
    public string name = "";
    public virtual void actionNull(ObjectMotionController obj)
    {

    }
    public virtual void action(IUsersInput input, ObjectMotionController obj)
    {

    }
    public virtual void actionCam(IUsersInput input, CameraMotionController obj)
    {

    }
}
