﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePoolView : BaseView
{
    private Dictionary<TileTypeEnum, List<GameObject>> tilePool = new Dictionary<TileTypeEnum, List<GameObject>>();

    public override void OnRegister()
    {
        dispatcher.AddListener(RootEvents.E_TileGameObjectInit, GiveTile);
        dispatcher.AddListener(RootEvents.E_TileSetToPool, ReceiveTile);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(RootEvents.E_TileGameObjectInit, GiveTile);
        dispatcher.RemoveListener(RootEvents.E_TileSetToPool, ReceiveTile);
    }

    private void GiveTile(strange.extensions.dispatcher.eventdispatcher.api.IEvent data)
    {
        if (tilePool != null)
        {
            TileModel tile = data.data as TileModel;

            if (tile != null)
            {
                if (tilePool.ContainsKey(tile.TileType))
                {
                    if (tilePool[tile.TileType] != null && tilePool[tile.TileType].Count > 0)
                    {
                        GameObject tileGameObject = tilePool[tile.TileType][0];

                        if (tileGameObject != null)
                        {
                            TileView tileView = tileGameObject.GetComponent<TileView>();

                            if (tileView != null)
                            {
                                tileView.Init(tile);
                            }

                            dispatcher.Dispatch(RootEvents.E_TileSetToWorld, tileGameObject);

                            tilePool[tile.TileType].Remove(tileGameObject);
                        }

                        else
                        {
                            Debug.LogError("tileGameObject == NULL");
                        }
                    }

                    else
                    {
                        Debug.LogError(string.Format("tilePool[{0}] == NULL", tile.TileType.ToString()));
                    }
                }

                else
                {
                    Debug.LogError(string.Format("tilePool not Contains {0} key", tile.TileType.ToString()));
                }
            }

            else
            {
                Debug.LogError("tile == NULL");
            }
        }

        else
        {
            Debug.LogError("tilePool == NULL");
        }

    }

    private void ReceiveTile(strange.extensions.dispatcher.eventdispatcher.api.IEvent data)
    {
        TileView tile = data.data as TileView;

        if (tile != null)
        {
            if (tilePool.ContainsKey(tile.TileType))
            {
                tilePool[tile.TileType].Add(tile.gameObject);
                tile.gameObject.transform.parent = gameObject.transform;
                tile.gameObject.transform.localPosition = Vector2.zero;
            }

            else
            {
                Debug.LogError(string.Format("tilePool not Contains {0} key", tile.TileType.ToString()));
            }
        }
    }

    public void FillTilePool(Dictionary<TileTypeEnum, List<GameObject>> tilePool)
    {
        this.tilePool = tilePool;
    }
}
