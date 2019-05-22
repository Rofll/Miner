﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCreationCommand : BaseCommand
{
    Vector2 playerPosition;

    public override void Execute()
    {
        Action<Vector2> callBack = GetPlayerPosition;

        dispatcher.Dispatch(RootEvents.E_PlayerPositionGet, callBack);

        //bool isWorldUpsideDown = false;

        //BuildWorldPart(playerPosition, world, renderWidth);
    }

    private void GetPlayerPosition(Vector2 playerPosition)
    {
        this.playerPosition = playerPosition;

        BuildWorldPart(playerPosition, GameModel.WorldSize, (int)GameModel.RenderWidth, GameModel.Seed);
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

                if (!(posY == (int)playerPos.y && posX == (int)playerPos.x))
                {
                    Debug.LogError(String.Format("Pos:[{0}][{1}]", posX, posY));
                    dispatcher.Dispatch(RootEvents.E_TileCreateRandom);
                }
            }
        }
    }
}
