using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : BaseView
{
    private Vector2Int playerPosition;

    public override void OnRegister()
    {
        dispatcher.AddListener(RootEvents.E_GetPlayerPosition, GivePlayerPosition);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(RootEvents.E_GetPlayerPosition, GivePlayerPosition);
    }

    public void Init(Vector2Int playerPosition)
    {
        this.playerPosition = playerPosition;
    }

    private void GivePlayerPosition(strange.extensions.dispatcher.eventdispatcher.api.IEvent data)
    {
        Debug.LogError("YEP");

        Action<Vector2Int> callBack = data.data as Action<Vector2Int>;

        if (callBack != null)
        {
            callBack.Invoke(playerPosition);
        }
    }

}
