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
        LootDropTable lootDropTable = new LootDropTable();

        List<LootObjectModel> lootObjectModel = new List<LootObjectModel>();

        lootObjectModel.Add(new LootObjectModel(ResourceTypesEnum.Core, 80, 3));
        lootObjectModel.Add(new LootObjectModel(ResourceTypesEnum.Crystal, 20, 3));
        lootObjectModel.Add(new LootObjectModel(ResourceTypesEnum.Gold, 10, 3));
        lootObjectModel.Add(new LootObjectModel(ResourceTypesEnum.Null, 20, 3));

        List<ResourceModel> tileResources = lootDropTable.GetLoot(lootObjectModel, 3, 10);

        foreach (ResourceModel tileResource in tileResources)
        {
            Debug.LogError(tileResource.ToString());
        }
    }
}
