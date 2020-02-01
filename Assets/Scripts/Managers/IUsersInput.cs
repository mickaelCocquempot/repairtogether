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

    public float GetX()
    {
        return Input.GetAxis(this.prefix + "Horizontal");
    }

    public float GetY()
    {
        return Input.GetAxis(this.prefix + "Vertical");
    }

    public float GetLT()
    {
        if (SystemInfo.operatingSystemFamily == OperatingSystemFamily.MacOSX)
        {
            return Input.GetAxis(this.prefix + "Trigger_LT_MAC");
        }
        else
        {
            return Input.GetAxis(this.prefix + "Trigger_LT_MS");
        }
    }

    public float GetRT()
    {
        if(SystemInfo.operatingSystemFamily == OperatingSystemFamily.MacOSX)
        {
            return Input.GetAxis(this.prefix + "Trigger_RT_MAC");
        }
        else
        {
            return Input.GetAxis(this.prefix + "Trigger_RT_MS");
        }
    }
}
