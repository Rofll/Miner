using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileView : BaseView
{

    private TileTypesEnum tileType;
    private List<ResourceModel> resourceses;

    public void Init(TileTypesEnum tileType, List<ResourceModel> resourceses)
    {
        this.tileType = tileType;
        this.resourceses = resourceses;
    }

    public override void OnRegister()
    {
    }

    public override void OnRemove()
    {

    }
}
