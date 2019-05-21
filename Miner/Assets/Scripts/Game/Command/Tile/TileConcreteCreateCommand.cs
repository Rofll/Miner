using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileConcreteCreateCommand : BaseCommand
{
    private const string RESOURCE_PATH = "Prefabs/Game/";
    private const string OBJECT_NAME = "Tile";

    private GameObject tileHolder;
    private TileModel tileModel;

    public override void Execute()
    {
        tileModel = eventData.data as TileModel;

        Action<GameObject> callBack = GetTileHolder;

        if (tileModel != null)
        {

            dispatcher.Dispatch(RootEvents.E_TileHolderGet, callBack);

            CreateTile(tileModel);
        }

        else
        {
            Debug.LogError("TileModel == NULL");
        }
    }

    private void GetTileHolder(GameObject tileHolder)
    {
        this.tileHolder = tileHolder;

        CreateTile(tileModel);
    }

    private void CreateTile(TileModel tileModel)
    {
        GameObject clone = UnityEngine.Object.Instantiate(Resources.Load(RESOURCE_PATH + OBJECT_NAME)) as GameObject;
        clone.name = OBJECT_NAME;
        clone.transform.parent = tileHolder.transform;


        TileView tileView = clone.GetComponent<TileView>();

        tileView.Init(tileModel);
    }
}
