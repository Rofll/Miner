using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RootEvents
{
    E_None,

    //  App Start
    E_AppStartNormal,
    E_AppStartDebug,
    //

    // Game
    E_PlayerCreate,
    E_PlayerPositionGet,
    
    E_TileCreateSpecific,
    E_TileCreateRandom,
    E_TileHolderGet,
    //


    E_End,
}
