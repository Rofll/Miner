using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileWorldHolderCreateCommand : BaseCommand
{
    private const string RESOURCE_PATH = "Prefabs/Game/Tile/";
    private const string OBJECT_NAME = "TileWorldHolder";

    public override void Execute()
    {
        Object prefab = Resources.Load(RESOURCE_PATH + OBJECT_NAME);

        GameObject clone = Object.Instantiate(prefab) as GameObject;
        clone.name = OBJECT_NAME;
    }
}
