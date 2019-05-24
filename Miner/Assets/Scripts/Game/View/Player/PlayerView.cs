using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : BaseView
{
    private Vector2 playerPosition;
    private Vector2 unityWorldPlayerPosition;
    private float playerSpeed = 1f;
    private bool isMovedOnThisFrame = false;
    private Coroutine waitForNewFreameCoroutine;


    public override void OnRegister()
    {
        dispatcher.AddListener(RootEvents.E_PlayerPositionGet, GivePlayerPosition);
        dispatcher.AddListener(RootEvents.E_InputOnKeyAction, OnInputAction);
        dispatcher.AddListener(RootEvents.E_PlayerUpdatePosition, UpdatePosition);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(RootEvents.E_PlayerPositionGet, GivePlayerPosition);
        dispatcher.RemoveListener(RootEvents.E_InputOnKeyAction, OnInputAction);
        dispatcher.RemoveListener(RootEvents.E_PlayerUpdatePosition, UpdatePosition);
    }

    public void UpdatePosition(Vector2 playerPosition)
    {
        this.playerPosition = playerPosition;
        unityWorldPlayerPosition = playerPosition;
        gameObject.transform.position = unityWorldPlayerPosition;
    }

    public void UpdatePosition(strange.extensions.dispatcher.eventdispatcher.api.IEvent data)
    {
        Vector2 newPlayerPosition = (Vector2) data.data;

        playerPosition = newPlayerPosition;
        unityWorldPlayerPosition = newPlayerPosition;
        gameObject.transform.position = unityWorldPlayerPosition;

        dispatcher.Dispatch(RootEvents.E_TileWorldCreate);
    }

    private void OnInputAction(strange.extensions.dispatcher.eventdispatcher.api.IEvent data)
    {
        InputActionStateModel inputActionModel = data.data as InputActionStateModel;

        if (inputActionModel != null)
        {
            if (!isMovedOnThisFrame)
            {
                switch (inputActionModel.InputAction)
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
                    //Debug.LogError("Yep");
                    
                    //Debug.LogError(gameObject.transform.position.ToString());

                    newPos = new Vector2(unityWorldPlayerPosition.x + (int)newPos.x, unityWorldPlayerPosition.y + (int)newPos.y);

                    Debug.LogError(unityWorldPlayerPosition.ToString());
                    Debug.LogError(newPos.ToString());

                    dispatcher.Dispatch(RootEvents.E_PlayerNewPosition, newPos);
                }
            }
        }
    }

    private IEnumerator WaitForNewFrame()
    {
        yield return null;
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
