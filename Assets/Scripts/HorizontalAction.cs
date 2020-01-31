using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalAction : IActions
{
    public override void action(string prefix, GameObject obj)
    {
        //obj.setmotion...
        Debug.Log(Input.GetAxis(prefix + "Horizontal"));
    }
}
