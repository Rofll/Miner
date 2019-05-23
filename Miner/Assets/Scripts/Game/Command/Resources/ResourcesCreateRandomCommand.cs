using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesCreateRandomCommand : BaseCommand
{
    public override void Execute()
    {
        ResourcesCreateCallBackModel resourcesCreateCallBackModel = eventData.data as ResourcesCreateCallBackModel;

        if (resourcesCreateCallBackModel != null)
        {
            CreateRandomTile(resourcesCreateCallBackModel.TileType, resourcesCreateCallBackModel.CallBack);
        }
        else
        {
            Debug.LogError("TileModel == NULL");
        }

    }

    private void CreateRandomTile(TileTypeEnum tileType, Action<List<ResourceModel>> callback)
    {
        LootDropTable<ResourceModel, ResourceTypesEnum> lootDropTable = new LootDropTable<ResourceModel, ResourceTypesEnum>();

        List<BucketObjectModel<ResourceTypesEnum>> lootObjectModel = new List<BucketObjectModel<ResourceTypesEnum>>();

        List<ResourceModel> resources = null;

        foreach (TileCreateModel tileCreateModel in GameModel.Tiles)
        {
            if (tileCreateModel.Type == tileType)
            {
                foreach (ResourceCreateModel resource in tileCreateModel.Resources)
                {
                    BucketObjectModel<ResourceTypesEnum> bucketObject = new BucketObjectModel<ResourceTypesEnum>(resource.Type, resource.Weight, resource.Count);
                    lootObjectModel.Add(bucketObject);
                }

                resources = lootDropTable.GetLoot(lootObjectModel, tileCreateModel.MinDrop, tileCreateModel.MaxDrop);
                break;
            }
        }


        if (resources != null)
        {
            callback.Invoke(resources);
        }

        else
        {
            Debug.LogError("resources == NULL");
        }
    }
}
