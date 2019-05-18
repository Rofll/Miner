using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class MainCameraMediator : BaseMediator
{
    [Inject]
    public MainCameraView view { get; set; }

    public override void OnRegister()
    {
        base.OnRegister();
        view.OnRegister();
    }

    public override void OnRemove()
    {
        base.OnRemove();
        view.OnRemove();
    }
}
