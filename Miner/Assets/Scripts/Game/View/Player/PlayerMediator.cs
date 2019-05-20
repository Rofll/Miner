using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class PlayerMediator : BaseMediator
{
    [Inject]
    public PlayerView view { get; set; }

    public override void OnRegister()
    {
        view.OnRegister();
    }

    public override void OnRemove()
    {
        view.OnRemove();
    }
}
