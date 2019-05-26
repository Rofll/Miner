using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InventoryCellView : BaseView
{
    private ResourceTypesEnum resourceType;

    [SerializeField]
    private Text resourceTypeText;

    public ResourceTypesEnum ResourceTypesEnum
    {
        get { return resourceType; }
    }

    public override void OnRegister()
    {
        dispatcher.AddListener(RootEvents.E_UI_ResourceUpdate, ResourceUpdate);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(RootEvents.E_UI_ResourceUpdate, ResourceUpdate);
    }

    public void InitResource(ResourceTypesEnum resourceType)
    {
        this.resourceType = resourceType;
        resourceTypeText.text = resourceType.ToString() + " 0";
    }

    private void ResourceUpdate(strange.extensions.dispatcher.eventdispatcher.api.IEvent data)
    {
        UI_ResourceUpdateModel resourceUpdateModel = data.data as UI_ResourceUpdateModel;

        if (resourceUpdateModel != null)
        {
            if (this.resourceType == resourceUpdateModel.ResourceType)
            {
                resourceTypeText.text = resourceType.ToString() + " " + resourceUpdateModel.Count.ToString();
            }
        }

       
    }
}
