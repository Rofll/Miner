using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : BaseView
{
    private Vector2 playerPosition;

    public override void OnRegister()
    {
        dispatcher.AddListener(RootEvents.E_PlayerPositionGet, GivePlayerPosition);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(RootEvents.E_PlayerPositionGet, GivePlayerPosition);
    }

    public void UpdatePosition(Vector2 playerPosition)
    {
        this.playerPosition = playerPosition;
        gameObject.transform.position = playerPosition;
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
