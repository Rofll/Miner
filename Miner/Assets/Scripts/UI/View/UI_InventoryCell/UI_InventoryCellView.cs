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
        resourceTypeText.text = resourceType.ToString() + ": 0";
    }

    private void ResourceUpdate(strange.extensions.dispatcher.eventdispatcher.api.IEvent data)
    {
        List<ResourceModel> resources = data.data as List<ResourceModel>;

        if (resources != null)
        {
            int count = 0;
            bool isFound = false;

            foreach (ResourceModel resourceModel in resources)
            {
                if (resourceModel != null && resourceType == resourceModel.ObjectType)
                {
                    isFound = true;
                    count++;
                    resourceTypeText.text = resourceType.ToString() + " " + count.ToString();
                }
            }

            if (!isFound)
            {
                resourceTypeText.text = resourceType.ToString() + " "  + 0;
            }
        }

    }
}
