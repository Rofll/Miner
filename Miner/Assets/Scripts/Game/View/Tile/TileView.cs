using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileView : BaseView
{

    private TileTypesEnum tileType;
    private List<ResourceModel> resourceses;
    private Vector2 position = Vector2.zero;

    public void Init(TileModel tileModel)
    {
        this.tileType = tileModel.TileType;
        this.resourceses = tileModel.Resources;
        this.position = tileModel.Position;
    }

    public override void OnRegister()
    {
    }

    public override void OnRemove()
    {

    }
}
