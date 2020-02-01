using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IActions
{
    public string name = "";
    protected IndicationScript indicationScript;
    public IActions(IndicationScript indicationScript) { this.indicationScript = indicationScript; }
    public virtual void actionNull(IUsersInput input, ObjectMotionController obj)
    {

    }
    public virtual void action(IUsersInput input, ObjectMotionController obj)
    {

    }
    public virtual void actionCam(IUsersInput input, CameraMotionController obj)
    {

    }
}
