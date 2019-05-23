using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRandomCreateCommand : BaseCommand
{
    public override void Execute()
    {
        Action<TileModel> tileCallBack = eventData.data as Action<TileModel>;

        if (tileCallBack != null)
        {
            CreateRandomTile(tileCallBack);
        }
        else
        {
            Debug.LogError("TileModel == NULL");
        }

    }

    private void CreateRandomTile(Action<TileModel> callback)
    {
        LootDropTable<TileModel, TileTypeEnum> lootDropTable = new LootDropTable<TileModel, TileTypeEnum>();

        List<BucketObjectModel<TileTypeEnum>> lootObjectModel = new List<BucketObjectModel<TileTypeEnum>>();

        foreach (TileCreateModel tileCreateModel in GameModel.Tiles)
        {
            BucketObjectModel<TileTypeEnum> bucketObject = new BucketObjectModel<TileTypeEnum>(tileCreateModel.Type, tileCreateModel.Weight, 1);
            lootObjectModel.Add(bucketObject);
        }

        List<TileModel> tileModels = lootDropTable.GetLoot(lootObjectModel, 1, 1);

        if (tileModels != null && tileModels.Count > 0)
        {
            callback.Invoke(tileModels[0]);
            //Debug.Log(tileModels[0].TileType);
        }
        else
        {
            Debug.LogError("Tile == NULL");
        }
    }
}
