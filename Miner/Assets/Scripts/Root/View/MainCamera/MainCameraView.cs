using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraView : BaseView 
{
    public override void OnRegister()
    {
        Debug.LogError("Hello");

        dispatcher.Dispatch(RootEvents.E_TileCreateSpecific);
    }

    public override void OnRemove()
    {

    }
}
