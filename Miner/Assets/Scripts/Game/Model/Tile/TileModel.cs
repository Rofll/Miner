using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileModel : ObjectModel<TileTypeEnum>
{
    public TileModel(TileTypeEnum tileType, int count = 1)
    {
        this.objectType = tileType;
        this.count = 1;
    }

    public TileModel(TileTypeEnum tileType, List<ResourceModel> resources, int count = 1)
    {
        this.resources = resources;
        this.objectType = tileType;
        this.count = 1;
    }

    public TileModel(TileTypeEnum tileType, List<ResourceModel> resources, Vector2 position, Vector2 unityWorldPosition, int count = 1)
    {
        this.resources = resources;
        this.objectType = tileType;
        this.position = position;
        this.unityWorldPosition = unityWorldPosition;
        this.count = 1;
    }

    private List<ResourceModel> resources;
    private Vector2 position;
    private Vector2 unityWorldPosition;

    public List<ResourceModel> Resources
    {
        get { return resources; }
    }

    public TileTypeEnum TileType
    {
        get { return objectType; }
    }

    public Vector2 Position
    {
        get { return position; }
    }

    public Vector2 UnityWorldPosition
    {
        get { return unityWorldPosition; }
    }

    public void InitPosition(Vector2 position)
    {
        this.position = position;
    }

    public void InitUnityWorldPosition(Vector2 unityWorldPosition)
    {
        this.unityWorldPosition = unityWorldPosition;
    }

    public void FillResources(List<ResourceModel> resources)
    {
        this.resources = resources;
    }
}
