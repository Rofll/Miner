using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : BaseView
{
    private Vector2 playerPosition;
    private Vector2 unityWorldPlayerPosition;
    private List<ResourceModel> inventory; 
    private float playerSpeed = 1f;
    private int inventoryMaxSlots = 20;
    private bool isMovedOnThisFrame = false;
    private Coroutine waitForNewFreameCoroutine;
    private List<InputActionEnum> inputAcion;


    public override void OnRegister()
    {
        dispatcher.AddListener(RootEvents.E_PlayerPositionGet, GivePlayerPosition);
        dispatcher.AddListener(RootEvents.E_InputOnKeyAction, OnInputAction);
        dispatcher.AddListener(RootEvents.E_PlayerUpdate, PlayerUpdate);

        inputAcion = new List<InputActionEnum>();

        inventory = new List<ResourceModel>();
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(RootEvents.E_PlayerPositionGet, GivePlayerPosition);
        dispatcher.RemoveListener(RootEvents.E_InputOnKeyAction, OnInputAction);
        dispatcher.RemoveListener(RootEvents.E_PlayerUpdate, PlayerUpdate);
    }

    public void UpdatePosition(Vector2 playerPosition)
    {
        this.playerPosition = playerPosition;
        unityWorldPlayerPosition = playerPosition;
        gameObject.transform.position = unityWorldPlayerPosition;
    }

    public void PlayerUpdate(strange.extensions.dispatcher.eventdispatcher.api.IEvent data)
    {
        TileView tileView = (TileView) data.data;

        bool isFoolRebuild = false;

        if (gameObject.transform.position.x < 0 || gameObject.transform.position.y < 0)
        {
            isFoolRebuild = true;
        }

        playerPosition = tileView.Position;
        unityWorldPlayerPosition = tileView.Position;
        gameObject.transform.position = unityWorldPlayerPosition;

        InventoryUpdate(tileView.Resources);

        Debug.LogError(inventory.Count);

        dispatcher.Dispatch(RootEvents.E_TileWorldCreate, playerPosition);
    }

    private void InventoryUpdate(List<ResourceModel> resources)
    {

        foreach (ResourceModel resource in resources)
        {

            if (inventory.Count >= inventoryMaxSlots)
            {
                inventory.RemoveAt(0);
            }

            inventory.Add(resource);

            dispatcher.Dispatch(RootEvents.E_UI_ResourceUpdate, new UI_ResourceUpdateModel(resource.ObjectType, resource.ObjectCount));

            if (resource.ObjectType == ResourceTypesEnum.Chest)
            {
                dispatcher.Dispatch(RootEvents.E_GameOverWin);
                return;
            }
        }
    }

    private void OnInputAction(strange.extensions.dispatcher.eventdispatcher.api.IEvent data)
    {
        InputActionStateModel inputActionModel = data.data as InputActionStateModel;

        if (inputActionModel != null)
        {

            if (!inputAcion.Contains(inputActionModel.InputAction))
            {
                inputAcion.Add(inputActionModel.InputAction);
            }

            else
            {
                if (inputActionModel.InputState == InputStateEnum.Up)
                {
                    inputAcion.Remove(inputActionModel.InputAction);
                    return;
                }
            }


            if (!isMovedOnThisFrame)
            {
                switch (inputAcion[inputAcion.Count - 1])
                {
                    case InputActionEnum.MoveUp:
                        playerPosition += Vector2.up * playerSpeed * Time.deltaTime;
                        break;
                    case InputActionEnum.MoveDown:
                        playerPosition += Vector2.down * playerSpeed * Time.deltaTime;
                        break;
                    case InputActionEnum.MoveLeft:
                        playerPosition += Vector2.left * playerSpeed * Time.deltaTime;
                        break;
                    case InputActionEnum.MoveRight:
                        playerPosition += Vector2.right * playerSpeed * Time.deltaTime;
                        break;
                    default:
                        break;
                }

                gameObject.transform.position = playerPosition;

                isMovedOnThisFrame = true;

                waitForNewFreameCoroutine = StartCoroutine(WaitForNewFrame());

                Vector2 newPos = new Vector2(gameObject.transform.position.x - unityWorldPlayerPosition.x, gameObject.transform.position.y - unityWorldPlayerPosition.y);

                if (Math.Abs(newPos.x) > 1f || Math.Abs(newPos.y) > 1f)
                {
                    newPos = new Vector2(unityWorldPlayerPosition.x + (int)newPos.x, unityWorldPlayerPosition.y + (int)newPos.y);

                    dispatcher.Dispatch(RootEvents.E_PlayerNewPosition, newPos);
                }
            }
        }
    }

    private IEnumerator WaitForNewFrame()
    {
        yield return new WaitForEndOfFrame();
        isMovedOnThisFrame = false;
    }

    private void GivePlayerPosition(strange.extensions.dispatcher.eventdispatcher.api.IEvent data)
    {
        Action<Vector2> callBack = data.data as Action<Vector2>;

        if (callBack != null)
        {
            callBack.Invoke(playerPosition);
        }
        else
        {
            Debug.LogError("CallBack == NULL");
        }
    }

}
