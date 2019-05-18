using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContextView : ContextViewRoot
{
    protected override void Start()
    {
        GameObject.DontDestroyOnLoad(this);
        instance = this;
        RunContext();
    }


    protected override void RunContext()
    {
        context = new GameContextRoot(this);
        context.Start();
    }
}
