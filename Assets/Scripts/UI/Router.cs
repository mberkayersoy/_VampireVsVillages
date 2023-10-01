using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum RouterPaths
{
    Main,
    AddPlayer,
    Roles,

    //Game Pages
    Start,
    Day,
    Vote,
    Night,
    End,
}

public class RouteChangedEvent
{
    public Router router;
    public RouterPaths newPath;
    public RouterPaths oldPath;
}

public class Router : MonoBehaviour
{
    public event EventHandler<RouteChangedEvent> OnPathChange;
    protected RouterPaths _path = RouterPaths.Main;
    public RouterPaths path
    {
        get { return _path; }
        set { UpdateRoute(value); }
    }

    public void UpdateRoute(RouterPaths newPath)
    {
        RouteChangedEvent e = new RouteChangedEvent() { router = this, oldPath= _path, newPath = newPath };
        _path = newPath;

        if (OnPathChange != null) OnPathChange?.Invoke(this, e);
    }
}
