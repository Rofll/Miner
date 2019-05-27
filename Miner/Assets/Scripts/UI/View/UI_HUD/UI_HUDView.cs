using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI_HUDView : BaseView
{
    [Header("Inventory Panel")]

    [SerializeField]
    private RectTransform InventoryPanel;

    [SerializeField]
    private GameObject inventoryContent;

    [SerializeField]
    private GameObject inventoryContentObject;

    [SerializeField]
    private Button inventoryButton;

    [SerializeField]
    private Transform MoveToTransform;

    [SerializeField]
    private Transform StartTransrom;

    private float startPosX;
    private float moveToPosX;
    
    private bool isInventoryOpen;

    public override void OnRegister()
    {
        inventoryButton.onClick.AddListener(OnInventoryButton);

        dispatcher.AddListener(RootEvents.E_InputOnKeyAction, OnInventoryButtonByKey);

        isInventoryOpen = false;
        startPosX = StartTransrom.transform.position.x;
        moveToPosX = MoveToTransform.transform.position.x;

        FillInventoryObjectTypes();

    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(RootEvents.E_InputOnKeyAction, OnInventoryButtonByKey);
    }

    private void OnInventoryButton()
    {
        if (!isInventoryOpen)
        {
            InventoryOpen();
            isInventoryOpen = true;
        }
        else
        {
            InventroyClose();
            isInventoryOpen = false;
        }
    }

    private void OnInventoryButtonByKey(strange.extensions.dispatcher.eventdispatcher.api.IEvent data)
    {
        InputActionStateModel inputActionModel = data.data as InputActionStateModel;

        if (inputActionModel != null)
        {

            if (inputActionModel.InputAction == InputActionEnum.InventoryOpen &&
                inputActionModel.InputState == InputStateEnum.Down)
            {
                OnInventoryButton();
            }
        }
    }

    private void InventoryOpen()
    {
        InventoryPanel.transform.DOMoveX(moveToPosX, 1f);
    }

    private void InventroyClose()
    {
        InventoryPanel.transform.DOMoveX(startPosX, 1f);
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
