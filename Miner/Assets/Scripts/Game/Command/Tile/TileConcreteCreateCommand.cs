using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileConcreteCreateCommand : BaseCommand
{
    private const string RESOURCE_PATH = "Prefabs/Game/";
    private const string OBJECT_NAME = "Tile";

    public override void Execute()
    {
        TileModel tileModel = eventData.data as TileModel;

        if (tileModel != null)
        {
            CreateTile(tileModel);
        }

        else
        {
            Debug.LogError("TileModel == NULL");
        }
    }

    private void CreateTile(TileModel tileModel)
    {
        GameObject clone = Object.Instantiate(Resources.Load(RESOURCE_PATH + OBJECT_NAME)) as GameObject;
        clone.name = OBJECT_NAME;

        TileView tileView = clone.GetComponent<TileView>();

        tileView.Init(tileModel.TileType, tileModel.Resources);
    }
}
