using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RootEvents
{
    E_None,

    ///////////////////////////////////////////////////  App Start
    E_AppStartNormal,
    E_AppStartDebug,
    ///////////////////////////////////////////////////

    /////////////////////////////////////////////////// Game

    // Player
    E_PlayerCreate,
    E_PlayerPositionGet,
    //

    // Tile
    E_TileCreateRandom,
    E_TileHolderGet,
    E_TileSetToWorld,
    E_TileGameObjectInit,
    E_TileWorldHolderCreate,
    //

    // Resources
    E_ResourcesCreateRandom,
    //


    ///////////////////////////////////////////////////


    E_End,
}
