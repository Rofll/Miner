using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileView : BaseView
{

    private TileTypesEnum tileType;
    private List<ResourceModel> resourceses;
    private Vector2 position = Vector2.zero;

    [SerializeField]
    private Renderer renderer;

    public void Init(TileModel tileModel)
    {
        this.tileType = tileModel.TileType;
        this.resourceses = tileModel.Resources;
        this.position = tileModel.Position;
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

    public void RenderOff()
    {
        renderer.enabled = false;
    }

    public void RenderOn()
    {
        renderer.enabled = true;
    }
}
