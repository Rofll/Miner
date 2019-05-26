using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI_HUDView : BaseView
{
    [SerializeField]
    private RectTransform InventoryPanel;

    [SerializeField]
    private GameObject inventoryContent;

    [SerializeField]
    private GameObject inventoryContentObject;

    [SerializeField]
    private Button inventoryButton;

    private bool isInventoryOpen;

    public override void OnRegister()
    {
        inventoryButton.onClick.AddListener(OnInventoryButton);

        isInventoryOpen = false;

        FillInventoryObjectTypes();
    }

    public override void OnRemove()
    {

    }

    private void OnInventoryButton()
    {
        if (!isInventoryOpen)
        {
            InventoryOpen();
        }
        else
        {
            InventroyClose();
        }
    }

    private void InventoryOpen()
    {
        InventoryPanel.transform.DOLocalMoveX(InventoryPanel.rect.width, 1f);
    }

    private void InventroyClose()
    {
        InventoryPanel.transform.DOLocalMoveX(0f, 1f);
    }

    private void FillInventoryObjectTypes()
    {
        for (int i = 0; i < (int)ResourceTypesEnum.End; i++)
        {
            if (i == (int)ResourceTypesEnum.Null)
                continue;

            GameObject inventoryContentObj = GameObject.Instantiate(inventoryContentObject, inventoryContent.transform);

            if (inventoryContentObj != null)
            {
                UI_InventoryCellView inventoryCellView = inventoryContentObj.GetComponent<UI_InventoryCellView>();

                if (inventoryCellView != null)
                {
                    inventoryCellView.InitResource((ResourceTypesEnum)i);
                }
            }
        }
    }
}
