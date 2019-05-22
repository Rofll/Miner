using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileChestCreateCommand : BaseCommand
{
    private TileModel tile;

    public override void Execute()
    {
        Action<TileModel> callBack = Callback;

        List<ResourceModel> chestResource = new List<ResourceModel>();

        chestResource.Add(new ResourceModel(ResourceTypesEnum.Chest, 1));

        dispatcher.Dispatch(RootEvents.E_TileCreateRandom, callBack);
    }

    private void Callback(TileModel tile)
    {
        this.tile = tile;

        FillTileChest();
    }

    private void FillTileChest()
    {
        List<ResourceModel> resources = new List<ResourceModel>();

        resources.Add(new ResourceModel(ResourceTypesEnum.Chest, 1));

        tile.FillResources(resources);

        Action<Vector2> callBack = SetChestRandomPosition;

        dispatcher.Dispatch(RootEvents.E_PlayerPositionGet, callBack);
    }

    private void SetChestRandomPosition(Vector2 playerPos)
    {
        Vector2 tilePosition = new Vector2(((GameModel.Seed + 1) * GameModel.WorldSize.y / 2 * 100 + playerPos.x) % GameModel.WorldSize.x,
            ((GameModel.Seed + 1) * GameModel.WorldSize.x / 3 * 100 + playerPos.y) % GameModel.WorldSize.y);

        while (tilePosition == playerPos)
        {
            tilePosition *= playerPos.x;
        }


        tile.InitPosition(tilePosition);

        GameModel.TileAddToMap(tile);
    }


}
