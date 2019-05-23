using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class TileWorldHolderMediator : BaseMediator
{
    [Inject]
    public TileWorldHolderView View { get; set; }

    public override void OnRegister()
    {
        View.OnRegister();
    }

    public override void OnRemove()
    {
        View.OnRemove();
    }
}
