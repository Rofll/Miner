using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChestCreateCommand : BaseCommand
{
    public override void Execute()
    {
        List<ResourceModel> chestResource = new List<ResourceModel>();

        chestResource.Add(new ResourceModel(ResourceTypesEnum.Chest, 1));

        //TileModel chestTile = new TileModel(chestResource,,);

        //GameModel.AddTileToMap()
    }
}
