using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IUsersInput
{
    public static int nUsers = 0;
    public string prefix = "";

    public int nActual = 0;
    public bool triggerLT = false;
    public bool triggerRT = false;

    public IActions action = null;

    public IUsersInput(){
        nUsers++;
        nActual = nUsers;
        prefix = "P" + nActual + "_";
    }

    public void act(ObjectMotionController obj, CameraMotionController objCam)
    {
        action.action(prefix, obj);
        action.actionCam(prefix, objCam);
    }
}
