using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_HUDMediator : BaseMediator
{
    [Inject]
    public UI_HUDView View { get; set; }

    public override void OnRegister()
    {
        View.OnRegister();
    }

    public override void OnRemove()
    {
        View.OnRemove();
    }
}
