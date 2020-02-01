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

    public Color color;

    public IUsersInput(){
        nUsers++;
        nActual = nUsers;
        prefix = "P" + nActual + "_";
        switch (nActual)
        {
            case 1:
                color = new Color(230f/255f, 49f / 255f, 46f / 255f);
                break;
            case 2:
                color = new Color(55f / 255f, 86f / 255f, 163f / 255f);
                break;
            case 3:
                color = new Color(222f / 255f, 139f / 255f, 6f / 255f);
                break;
            case 4:
                color = new Color(12f / 255f, 147 / 255f, 56f / 255f);
                break;
            default:
                color = new Color(12f / 255f, 147 / 255f, 56f / 255f);
        }
    }

    public void act(ObjectMotionController obj, CameraMotionController objCam)
    {
        action.action(this, obj);
        action.actionCam(this, objCam);
    }

    public float GetHorizontal()
    {
        return Input.GetAxis(this.prefix + "Horizontal");
    }

    public float GetVertical()
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
