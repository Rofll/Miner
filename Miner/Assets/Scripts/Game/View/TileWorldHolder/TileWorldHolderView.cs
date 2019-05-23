using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileWorldHolderView : BaseView
{
    private Dictionary<Vector2, List<GameObject>> tilesWorld = new Dictionary<Vector2, List<GameObject>>();

    public override void OnRegister()
    {
       dispatcher.AddListener(RootEvents.E_TileSetToWorld, ReceiveTile);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(RootEvents.E_TileSetToWorld, ReceiveTile);
    }

    private void ReceiveTile(strange.extensions.dispatcher.eventdispatcher.api.IEvent data)
    {
        if (tilesWorld != null)
        {
            GameObject tileGameObject = data.data as GameObject;

            if (tileGameObject != null)
            {
                TileView tile = tileGameObject.GetComponent<TileView>();

                if (tile != null)
                {
                    if (!tilesWorld.ContainsKey(tile.Position))
                    {
                        tilesWorld.Add(tile.Position, new List<GameObject>() { tileGameObject });
                    }

                    tileGameObject.transform.position = tile.UnityWorldPosition;
                    tileGameObject.transform.parent = gameObject.transform;

                    tile.OnSpawn();
                }
            }

            else
            {
                Debug.LogError("tileGameObject == NULL");
            }
        }

        else
        {
            Debug.LogError("tilesWorld == NULL");
        }
    }

    private void GiveTyle()
    {

    }
}
