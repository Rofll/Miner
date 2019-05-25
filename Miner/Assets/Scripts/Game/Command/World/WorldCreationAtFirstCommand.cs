using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCreationAtFirstCommand : BaseCommand
{
    public override void Execute()
    {
        Action<Vector2> callBack = GetPlayerPosition;
        dispatcher.Dispatch(RootEvents.E_PlayerPositionGet, callBack);
    }

    private void GetPlayerPosition(Vector2 playerPosition)
    {
        dispatcher.Dispatch(RootEvents.E_TileWorldCreate, playerPosition);
    }
}
