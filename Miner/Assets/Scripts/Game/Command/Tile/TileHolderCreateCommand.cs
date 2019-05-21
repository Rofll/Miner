using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHolderCreateCommand : BaseCommand
{
    private const string RESOURCE_PATH = "Prefabs/Game/Tile/";
    private const string OBJECT_NAME = "TileHolder";

    public override void Execute()
    {
        Object prefab = Resources.Load(OBJECT_NAME + OBJECT_NAME);

        GameObject clone = Object.Instantiate(prefab) as GameObject;
        clone.name = OBJECT_NAME;
    }
}
