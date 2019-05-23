using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePoolCreateCommand : BaseCommand
{
    private const string RESOURCE_PATH = "Prefabs/Game/Tile/";
    private const string RESOURCE_PATH_TILE = "Prefabs/Game/Tile/Tiles/";
    private const string OBJECT_NAME = "TilePool";
    private const string OBJECT_NAME_Tile = "Tile_";
    private Vector2 position = new Vector2(-10000f, -10000f);

    public override void Execute()
    {
        Object playerObject = GameObject.Find(OBJECT_NAME);

        if (!playerObject)
        {
            playerObject = Resources.Load(RESOURCE_PATH + OBJECT_NAME) as GameObject;

            if (playerObject)
            {
                GameObject clone = Object.Instantiate(playerObject) as GameObject;
                clone.name = OBJECT_NAME;
                clone.transform.position = position;

                TilePoolView tilePoolView = clone.GetComponent<TilePoolView>();

                if (tilePoolView != null)
                {

                    int totalTileOneType = (int) GameModel.PlayerWidth * 8;

                    Dictionary<TileTypeEnum, List<GameObject>> tilePool = new Dictionary<TileTypeEnum, List<GameObject>>();

                    List<GameObject> tilesType;

                    for (int i = 0; i < (int) TileTypeEnum.End; i++)
                    {
                        if ((TileTypeEnum) i != TileTypeEnum.Null)
                        { 
                            tilesType = new List<GameObject>();

                            for (int j = 0; j < totalTileOneType; j++)
                            {
                                GameObject tileGameObject = CreateTileGameObject((TileTypeEnum) i, clone.transform);

                                if (tileGameObject == null)
                                {
                                    Debug.LogError("tileGameObject == NULL");
                                    break;
                                }

                                tilesType.Add(tileGameObject);
                            }

                            tilePool.Add((TileTypeEnum) i, tilesType);
                        }

                    }

                    tilePoolView.FillTilePool(tilePool);
                }
            }

            else
            {
                Debug.LogError(OBJECT_NAME + " == NULL");
            }
        }

        else
        {
            Debug.LogError(OBJECT_NAME + " == Already Exists");
        }
    }

    private GameObject CreateTileGameObject(TileTypeEnum tileType, Transform parent)
    {
        Object obj = Resources.Load(RESOURCE_PATH_TILE + OBJECT_NAME_Tile + tileType.ToString());

        if (obj != null)
        {
            GameObject clone = Object.Instantiate(obj) as GameObject;

            clone.name = OBJECT_NAME_Tile + tileType.ToString();
            clone.transform.parent = parent;

            TileView tileView = clone.GetComponent<TileView>();

            tileView.OnDeSpawn();

            return clone;
        }

        else
        {
            Debug.LogError(RESOURCE_PATH_TILE + OBJECT_NAME_Tile + tileType.ToString() + " == NULL");
            return null;
        }

    }
}
