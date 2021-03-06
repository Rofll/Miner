﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCreationCommand : BaseCommand
{
    private static bool isUpsideDown = false;
    private static Vector2 playerPositionOld = Vector2.down;

    public override void Execute()
    {
        Vector2 playerPosition = (Vector2)eventData.data;

        CoroutineWorker.StarCoroutine(WaitForEndOfFrame(playerPosition));
    }

    private IEnumerator WaitForEndOfFrame(Vector2 playerPosition)
    {
        yield return new WaitForEndOfFrame();

        if (playerPositionOld != Vector2.down)
        {
            if (Math.Abs(playerPosition.x - playerPositionOld.x) > 1 && Math.Abs(playerPosition.x - playerPositionOld.x) != GameModel.WorldSize.x - 1)
            {
                isUpsideDown = !isUpsideDown;

                //Debug.LogError(isUpsideDown.ToString());
            }
        }

        playerPositionOld = playerPosition;

        BuildWorldPart(playerPosition, GameModel.WorldSize, (int)GameModel.PlayerWidth, GameModel.Seed);
    }

    private void BuildWorldPart(Vector2 playerPos, Vector2Int world, int renderWidth, uint seed)
    {
        //int countY = 0;
        //int countX = 0;

        int worldHalfX = world.x / 2;


        for (int i = (int)playerPos.y - renderWidth; i <= playerPos.y + renderWidth; i++)
        {

            //countY++;
            //countX = 0;

            int posY;

            if (i < 0)
            {
                posY = -i - 1;
            }

            else if (i > world.y - 1)
            {
                posY = (world.y - 1) - (i - world.y);
            }

            else
            {
                posY = i;
            }

            for (int j = (int)playerPos.x - renderWidth; j <= playerPos.x + renderWidth; j++)
            {
                //countX++;

                int posX;

                if (i < 0)
                {
                    if (j < worldHalfX)
                    {
                        posX = worldHalfX + j;

                        //Debug.LogError("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

                        //Debug.LogError("CountY: " + countY.ToString() + " CountX: " + countX.ToString());

                        //Debug.LogError("Current i: " + i.ToString());
                        //Debug.LogError("Current j: " + j.ToString());

                        //Debug.LogError("Current PosX: " + posX.ToString());
                        //Debug.LogError("Current PosY: " + posY.ToString());
                    }

                    else
                    {
                        posX = j - worldHalfX;

                        //Debug.LogError("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

                        //Debug.LogError("CountY: " + countY.ToString() + " CountX: " + countX.ToString());

                        //Debug.LogError("Current i: " + i.ToString());
                        //Debug.LogError("Current j: " + j.ToString());

                        //Debug.LogError("Current PosX: " + posX.ToString());
                        //Debug.LogError("Current PosY: " + posY.ToString());
                    }
                }

                else if (i > world.y - 1)
                {

                    if (j > worldHalfX)
                    {
                        posX = j - worldHalfX;

                        //Debug.LogError("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

                        //Debug.LogError("CountY: " + countY.ToString() + " CountX: " + countX.ToString());

                        //Debug.LogError("Current i: " + i.ToString());
                        //Debug.LogError("Current j: " + j.ToString());

                        //Debug.LogError("Current PosX: " + posX.ToString());
                        //Debug.LogError("Current PosY: " + posY.ToString());
                    }

                    else
                    {
                        posX = worldHalfX + j;

                        //Debug.LogError("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

                        //Debug.LogError("CountY: " + countY.ToString() + " CountX: " + countX.ToString());

                        //Debug.LogError("Current i: " + i.ToString());
                        //Debug.LogError("Current j: " + j.ToString());

                        //Debug.LogError("Current PosX: " + posX.ToString());
                        //Debug.LogError("Current PosY: " + posY.ToString());
                    }
                }

                else if (j > world.x - 1)
                {
                    posX = j % world.x;

                    //Debug.LogError("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

                    //Debug.LogError("CountY: " + countY.ToString() + " CountX: " + countX.ToString());

                    //Debug.LogError("Current i: " + i.ToString());
                    //Debug.LogError("Current j: " + j.ToString());

                    //Debug.LogError("Current PosX: " + posX.ToString());
                    //Debug.LogError("Current PosY: " + posY.ToString());
                }

                else if (j < 0)
                {
                    posX = world.x + j;

                    //Debug.LogError("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

                    //Debug.LogError("CountY: " + countY.ToString() + " CountX: " + countX.ToString());

                    //Debug.LogError("Current i: " + i.ToString());
                    //Debug.LogError("Current j: " + j.ToString());

                    //Debug.LogError("Current PosX: " + posX.ToString());
                    //Debug.LogError("Current PosY: " + posY.ToString());
                }

                else
                {
                    posX = j;

                    //Debug.LogError("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

                    //Debug.LogError("CountY: " + countY.ToString() + " CountX: " + countX.ToString());

                    //Debug.LogError("Current i: " + i.ToString());
                    //Debug.LogError("Current j: " + j.ToString());

                    //Debug.LogError("Current PosX: " + posX.ToString());
                    //Debug.LogError("Current PosY: " + posY.ToString());
                }

                Vector2 tilePos = new Vector2(posX, posY);
                Vector2 unityWorldPosition = new Vector2(j, i);

                if (!(posY == (int)playerPos.y && posX == (int)playerPos.x))
                {
                    if (GameModel.Map.ContainsKey(tilePos))
                    {
                        SetTileFromMap(tilePos, unityWorldPosition);
                    }

                    else
                    {
                        SetTileRandom(tilePos, unityWorldPosition);
                    }

                    //Debug.LogError("Current j: " + j.ToString());
                    //Debug.LogError("Current i: " + i.ToString());
                    //Debug.LogError("Tile Pos");
                    //Debug.LogError(tilePos.ToString());

                }

                else
                {
                    SetNullTile(tilePos, unityWorldPosition);
                }
            }
        }

        dispatcher.Dispatch(RootEvents.E_TileSetToWorldComplete, isUpsideDown);
    }

    private TileModel tile;
    private Vector2 tilePosition;
    private Vector2 unityWorldPosition;

    private void SetTileRandom(Vector2 position, Vector2 unityWorldPosition)
    {
        tilePosition = position;
        this.unityWorldPosition = unityWorldPosition;

        Action<TileModel> callBackTile = GetTileCallBack;

        dispatcher.Dispatch(RootEvents.E_TileCreateRandom, callBackTile);
    }

    private void GetTileCallBack(TileModel tile)
    {
        this.tile = tile;

        Action<List<ResourceModel>> callBackResources = GetResourcesCallBack;

        dispatcher.Dispatch(RootEvents.E_ResourcesCreateRandom, new ResourcesCreateCallBackModel(tile.TileType, GetResourcesCallBack));
    }

    private void GetResourcesCallBack(List<ResourceModel> resources)
    {
        tile.FillResources(resources);

        SetTileToWorld(tile);
    }

    private void SetTileToWorld(TileModel tile)
    {
        tile.InitPosition(tilePosition);
        tile.InitUnityWorldPosition(unityWorldPosition);

        GameModel.TileAddToMap(tile);

        Debug.Log(String.Format("Tile {0} Pos:[{1}][{2}]    PosUnity:[{3}][{4}]", tile.TileType.ToString(), tilePosition.x, tilePosition.y, unityWorldPosition.x, unityWorldPosition.y));

        dispatcher.Dispatch(RootEvents.E_TileGameObjectInit, tile);
    }

    private void SetNullTile(Vector2 position, Vector2 unityWorldPosition)
    {
        TileModel tile = new TileModel(TileTypeEnum.Empty, new List<ResourceModel>(), position, unityWorldPosition);

        GameModel.TileRewriteToMap(tile);

        dispatcher.Dispatch(RootEvents.E_TileGameObjectInit, tile);
    }

    private void SetTileFromMap(Vector2 position, Vector2 unityWorldPosition)
    {
        TileModel tile = GameModel.Map[position];
        tile.InitUnityWorldPosition(unityWorldPosition);

        if (tile != null)
        {
            dispatcher.Dispatch(RootEvents.E_TileGameObjectInit, tile);
        }
    }
}
