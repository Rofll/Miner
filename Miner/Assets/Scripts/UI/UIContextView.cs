using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIContextView : ContextViewRoot
{
    protected override void Start()
    {
        GameObject.DontDestroyOnLoad(this);
        RunContext();
    }


    protected override void RunContext()
    {
        context = new UIContextRoot(this);
        //context.Start();
    }
}

