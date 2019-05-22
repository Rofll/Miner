using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRandomCreateCommand : BaseCommand
{
    public override void Execute()
    {
        CreateRandomTile();
    }

    private void CreateRandomTile()
    {
        LootDropTable<TileModel, TileTypesEnum> lootDropTable = new LootDropTable<TileModel, TileTypesEnum>();

        List<BucketObjectModel<TileTypesEnum>> lootObjectModel = new List<BucketObjectModel<TileTypesEnum>>();

        //foreach (var VARIABLE in COLLECTION)
        //{
        //    lootObjectModel.Add();
        //}

        //LootDropTable<ResourceModel, ResourceTypesEnum> lootDropTable = new LootDropTable<ResourceModel, ResourceTypesEnum>();

        //List<BucketObjectModel<ResourceTypesEnum>> lootObjectModel = new List<BucketObjectModel<ResourceTypesEnum>>();

        //lootObjectModel.Add(new BucketObjectModel<ResourceTypesEnum>(ResourceTypesEnum.Core, 80, 3));
        //lootObjectModel.Add(new BucketObjectModel<ResourceTypesEnum>(ResourceTypesEnum.Crystal, 20, 3));
        //lootObjectModel.Add(new BucketObjectModel<ResourceTypesEnum>(ResourceTypesEnum.Gold, 10, 3));
        //lootObjectModel.Add(new BucketObjectModel<ResourceTypesEnum>(ResourceTypesEnum.Null, 20, 3));

        //List<ResourceModel> tileResources = lootDropTable.GetLoot(lootObjectModel, 100, 100, true);

        //foreach (ResourceModel tileResource in tileResources)
        //{
        //    Debug.LogError(tileResource.ToString());
        //}
    }
}
