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
        LootDropTable<TileModel, TileTypesEnum> lootDropTable = new LootDropTable<TileModel, TileTypesEnum>();

        List<BucketObjectModel<TileTypesEnum>> lootObjectModel = new List<BucketObjectModel<TileTypesEnum>>();

        foreach (TileCreateModel tileCreateModel in GameModel.Tiles)
        {
            BucketObjectModel<TileTypesEnum> bucketObject = new BucketObjectModel<TileTypesEnum>(tileCreateModel.Type, tileCreateModel.Weight, 1);
            lootObjectModel.Add(bucketObject);
        }

        List<TileModel> tileModels = lootDropTable.GetLoot(lootObjectModel, 1, 1);

        if (tileModels != null && tileModels.Count > 0)
        {
            callback.Invoke(tileModels[0]);
            Debug.LogError(tileModels[0].TileType);
        }
        else
        {
            Debug.LogError("Tile == NULL");
        }
    }
}
