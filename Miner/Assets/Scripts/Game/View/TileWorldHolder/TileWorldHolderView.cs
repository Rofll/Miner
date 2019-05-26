using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileWorldHolderView : BaseView
{
    private Dictionary<Vector2, List<GameObject>> tilesWorld = new Dictionary<Vector2, List<GameObject>>();

    public override void OnRegister()
    {
       dispatcher.AddListener(RootEvents.E_TileSetToWorld, ReceiveTile);
       dispatcher.AddListener(RootEvents.E_PlayerNewPosition, OnPlayerNewPosition);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(RootEvents.E_TileSetToWorld, ReceiveTile);
        dispatcher.RemoveListener(RootEvents.E_PlayerNewPosition, OnPlayerNewPosition);
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
                    if (!tilesWorld.ContainsKey(tile.UnityWorldPosition))
                    {
                        tilesWorld.Add(tile.UnityWorldPosition, new List<GameObject>() { tileGameObject });
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

    private void OnPlayerNewPosition(strange.extensions.dispatcher.eventdispatcher.api.IEvent data)
    {
        Vector2 playerPosition = (Vector2) data.data;

        if (tilesWorld.ContainsKey(playerPosition))
        {
            TileView tileView = tilesWorld[playerPosition][0].gameObject.GetComponent<TileView>();

            if (tileView != null)
            {
                dispatcher.Dispatch(RootEvents.E_PlayerUpdate, tileView);
                GiveTyle();
            }
        }
    }

    private void GiveTyle()
    {
        foreach (var tile in tilesWorld)
        {
            TileView tileView = tile.Value[0].GetComponent<TileView>();

            if (tileView != null)
            {
                tileView.OnDeSpawn();
                dispatcher.Dispatch(RootEvents.E_TileSetToPool, tileView);
            }
        }

        tilesWorld.Clear();
    }
}
