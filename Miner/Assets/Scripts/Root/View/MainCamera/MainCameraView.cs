using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MainCameraView : BaseView
{

    private Action<Vector2> playerPositionCallBack;
    private Vector2 playerPosition = Vector2.zero;

    private Coroutine folowPlayerCoroutine;

    public override void OnRegister()
    {
        Debug.LogError("Hello");

        dispatcher.AddListener(RootEvents.E_CameraMainStartFolowPlayer, OnCameraMainStartFolowPlayer);
        dispatcher.AddListener(RootEvents.E_CameraMainStopFolowPlayer, OnCameraMainStopFolowPlayer);

        playerPositionCallBack = GetPlayerPosition;
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(RootEvents.E_CameraMainStartFolowPlayer, OnCameraMainStartFolowPlayer);
        dispatcher.RemoveListener(RootEvents.E_CameraMainStopFolowPlayer, OnCameraMainStopFolowPlayer);
    }


    private void OnCameraMainStartFolowPlayer()
    {
        folowPlayerCoroutine = StartCoroutine(FolowPlayer());
    }

    private IEnumerator FolowPlayer()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();

            dispatcher.Dispatch(RootEvents.E_PlayerPositionGet, playerPositionCallBack);
        }
    }

    private void GetPlayerPosition(Vector2 playerPosition)
    {
        this.playerPosition = playerPosition;

        gameObject.transform.position = new Vector3(playerPosition.x, playerPosition.y, gameObject.transform.position.z);
    }

    private void OnCameraMainStopFolowPlayer()
    {
        if (folowPlayerCoroutine != null)
        {
            StopCoroutine(folowPlayerCoroutine);
        }
    }
}
