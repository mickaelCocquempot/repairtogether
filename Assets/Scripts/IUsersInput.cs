﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IUsersInput
{
    public static int nUsers = 0;
    public string prefix = "";

    private int nActual = 0;

    public IActions action = null;

    public IUsersInput(){
        nUsers++;
        nActual = nUsers;
        prefix = "P" + nActual + "_";
    }

    public void act()
    {
        action.action(prefix, null);
    }
}
