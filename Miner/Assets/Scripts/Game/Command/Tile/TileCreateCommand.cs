using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCreateCommand : BaseCommand
{
    public override void Execute()
    {
        List<ResourceModel> resources = new List<ResourceModel>();
        TileTypesEnum tileType = TileTypesEnum.Stone;

        resources.Add(new ResourceModel(ResourceTypesEnum.Core, 1));

        GameObject clone = Object.Instantiate(Resources.Load("Prefabs/Game/Tile")) as GameObject;

        TileView tileView = clone.GetComponent<TileView>();

        tileView.Init(tileType, resources);

    }
}
