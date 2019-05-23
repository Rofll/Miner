using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesCreateCallBackModel
{
    public ResourcesCreateCallBackModel(TileTypeEnum tileType, Action<List<ResourceModel>> callBack)
    {
        this.tileType = tileType;
        this.callBack = callBack;
    }

    private readonly TileTypeEnum tileType;
    private readonly Action<List<ResourceModel>> callBack;

    public TileTypeEnum TileType
    {
        get { return tileType; }
    }

    public Action<List<ResourceModel>> CallBack
    {
        get { return callBack; }
    }
}
