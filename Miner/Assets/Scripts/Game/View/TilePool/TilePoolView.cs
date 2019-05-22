using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePoolView : BaseView
{
    private Dictionary<TileTypesEnum, List<GameObject>> tilePool;

    public override void OnRegister()
    {

    }

    public override void OnRemove()
    {

    }

    private void GiveTile()
    {

    }

    private void TakeTile()
    {

    }

    public void FillTilePool(Dictionary<TileTypesEnum, List<GameObject>> tilePool)
    {
        this.tilePool = tilePool;
    }
}
