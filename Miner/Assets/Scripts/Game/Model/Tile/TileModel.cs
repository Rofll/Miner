using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileModel
{
    public TileModel(List<ResourceModel> resources, TileTypesEnum tileType)
    {
        this.resources = resources;
        this.tileType = tileType;
    }

    private readonly List<ResourceModel> resources;
    private readonly TileTypesEnum tileType;

    public List<ResourceModel> Resources
    {
        get { return resources; }
    }

    public TileTypesEnum TileType
    {
        get { return tileType; }
    }
}
