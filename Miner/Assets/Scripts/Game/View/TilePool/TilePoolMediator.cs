using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class TilePoolMediator : BaseMediator
{
    [Inject]
    public TilePoolView View { get; set; }

    public override void OnRegister()
    {
        View.OnRegister();
    }

    public override void OnRemove()
    {
        View.OnRegister();
    }
}
