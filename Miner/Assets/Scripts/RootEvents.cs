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

    // Input
    E_InputOnKeyAction,
    //

    // Game Root

    E_GameOverWin,

    //

    // Camera

    E_CameraMainStartFolowPlayer,
    E_CameraMainStopFolowPlayer,

    //

    // Player
    E_PlayerCreate,
    E_PlayerPositionGet,
    E_PlayerNewPosition,
    E_PlayerUpdate,
    //

    // Tile
    E_TileCreateRandom,
    E_TileHolderGet,
    E_TileSetToWorld,
    E_TileSetToPool,
    E_TileGameObjectInit,
    E_TileWorldHolderCreate,
    E_TileWorldCreate,
    E_TileSetToWorldComplete,
    //

    // Resources
    E_ResourcesCreateRandom,
    E_UI_ResourceUpdate,
    //


    ///////////////////////////////////////////////////


    /////////////////////////////////////////////////// UI

    E_UI_HUDCreateCommand,
    E_UI_HUDDestoryCommand,

    /////////////////////////////////////////////////// 

    E_End,
}
