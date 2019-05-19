using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class TileMediator : BaseMediator
{
    [Inject]
    public TileView View { get; set; }


    public override void OnRegister()
    {
        base.OnRegister();
        View.OnRegister();
    }

    public override void OnRemove()
    {
        base.OnRemove();
        View.OnRemove();
    }
}
