using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileWorldHolderView : BaseView
{
    private Dictionary<Vector2, List<GameObject>> tilesWorld = new Dictionary<Vector2, List<GameObject>>();

    public override void OnRegister()
    {
        dispatcher.AddListener(RootEvents.E_TileSetToWorld, ReceiveTile);
        dispatcher.AddListener(RootEvents.E_PlayerNewPosition, OnPlayerNewPosition);
        dispatcher.AddListener(RootEvents.E_TileSetToWorldComplete, OnWorldBuildComplete);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(RootEvents.E_TileSetToWorld, ReceiveTile);
        dispatcher.RemoveListener(RootEvents.E_PlayerNewPosition, OnPlayerNewPosition);
        dispatcher.RemoveListener(RootEvents.E_TileSetToWorldComplete, OnWorldBuildComplete);
    }

    private void PlayerPositionGetCallBack( Vector2 playerPosition)
    {
        Dictionary<Vector2, List<GameObject>> reverseTilesWorld = new Dictionary<Vector2, List<GameObject>>();

        foreach (Vector2 unityWorldPosition in tilesWorld.Keys)
        {
            //Debug.LogError(unityWorldPosition.y);

            if (unityWorldPosition.y > playerPosition.y)
            {
                Vector2 newPos = new Vector2(unityWorldPosition.x, playerPosition.y - (unityWorldPosition.y - playerPosition.y));

                //Debug.LogError(newPos);

                Vector2 oldPos = unityWorldPosition;

                List<GameObject> tmpListThis = tilesWorld[oldPos];
                List<GameObject> tmpListThere = tilesWorld[newPos];

                //tilesWorld.Remove(newPos);
                //tilesWorld.Remove(oldPos);

                tmpListThis[0].gameObject.transform.position = new Vector3(newPos.x, newPos.y, tmpListThis[0].gameObject.transform.position.z);
                tmpListThere[0].gameObject.transform.position = new Vector3(oldPos.x, oldPos.y, tmpListThere[0].gameObject.transform.position.z);

                reverseTilesWorld.Add(newPos, tmpListThis);
                reverseTilesWorld.Add(oldPos, tmpListThere);

                //reverseTilesWorld[newPos] = tmpListThis;
                //reverseTilesWorld[oldPos] = tmpListThere;

            }

            else if (unityWorldPosition.y == playerPosition.y)
            {
                reverseTilesWorld.Add(unityWorldPosition, tilesWorld[unityWorldPosition]);
            }
        }

        //Debug.LogError(tilesWorld.Keys.Count);

        tilesWorld = reverseTilesWorld;
    }

    private void OnWorldBuildComplete(strange.extensions.dispatcher.eventdispatcher.api.IEvent data)
    {
        bool isUpsideDown = (bool)data.data;

        if (isUpsideDown)
        {
            Action<Vector2> callBack = PlayerPositionGetCallBack;

            dispatcher.Dispatch(RootEvents.E_PlayerPositionGet, callBack);
        }
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
        //Debug.LogError(tilesWorld.Count);

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
