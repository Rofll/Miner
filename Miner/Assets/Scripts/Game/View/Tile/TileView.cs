﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileView : BaseView
{

    private TileTypeEnum tileType;
    private List<ResourceModel> resources;
    private Vector2 position = Vector2.zero;
    private Vector2 unityWorldPosition = Vector2.zero;

    [SerializeField]
    private Renderer renderer;


    public TileTypeEnum TileType
    {
        get { return tileType; }
    }

    public List<ResourceModel> Resources
    {
        get { return resources; }
    }

    public Vector2 Position
    {
        get { return position; }
    }

    public Vector2 UnityWorldPosition
    {
        get { return unityWorldPosition; }
    }


    public void Init(TileModel tileModel)
    {
        this.tileType = tileModel.TileType;
        this.resources = tileModel.Resources;
        this.position = tileModel.Position;
        this.unityWorldPosition = tileModel.UnityWorldPosition;
    }

    public override void OnRegister()
    {
        if (renderer == null)
        {
            Debug.LogError("renderer == NULL " + gameObject.name);
        }
    }

    public override void OnRemove()
    {

    }

    public void OnSpawn()
    {
        renderer.enabled = true;
    }

    public void OnDeSpawn()
    {
        renderer.enabled = false;
    }
}
