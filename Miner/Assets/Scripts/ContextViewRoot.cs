using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.dispatcher.eventdispatcher.api;

public abstract class ContextViewRoot : strange.extensions.context.impl.ContextView
{
    protected abstract void RunContext();

    protected abstract void Start();

    protected virtual void Update()
    {
    }

    protected virtual void FixedUpdate()
    {
    }

    protected virtual void LateUpdate()
    {
    }

    protected virtual void OnApplicationPause(bool pauseStatus)
    {
    }

    protected virtual void OnApplicationFocus(bool focus)
    {
    }

}