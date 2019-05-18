using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

public class MainContextView : ContextViewRoot
{
    public static IEventDispatcher strangeDispatcher = null;
    public bool IsDebug = false;

    private void Awake()
    {
#if UNITY_EDITOR
        if (IsDebug)
        {
            AppLoadCommand.isNormalStart = false;
        }
#endif
        GameObject.DontDestroyOnLoad(this);
        instance = this;

        RunContext();
    }

    protected override void Start()
    {

    }


    protected override void RunContext()
    {
        context = new MainContextRoot(this);
        context.Start();
    }

    private void InitDispather()
    {
        strangeDispatcher = (instance.context as MainContextRoot).dispatcher;
    }

    public static void DispatchStrangeEvent(object eventType)
    {
        if (strangeDispatcher != null)
        {
            strangeDispatcher.Dispatch(eventType);
        }
        else
        {
            Debug.LogWarning("strangeDispatcher Not Ready");
        }
    }

    public static void DispatchStrangeEvent(object eventType, object data)
    {

        if (strangeDispatcher != null)
        {
            strangeDispatcher.Dispatch(eventType, data);
        }
        else
        {
            Debug.LogWarning("strangeDispatcher Not Ready");
        }
    }

    /// Remove a previously registered observer with exactly one argument from this Dispatcher
    public static void AddListenerStrangeEvent(object evt, EventCallback callback)
    {
        if (strangeDispatcher != null)
        {
            strangeDispatcher.AddListener(evt, callback);
        }
        else
        {
            Debug.LogWarning("strangeDispatcher Not Ready");
        }
    }

    public static void AddListenerStrangeEvent(object evt, EmptyCallback callback)
    {
        if (strangeDispatcher != null)
        {
            strangeDispatcher.AddListener(evt, callback);
        }
        else
        {
            Debug.LogWarning("strangeDispatcher Not Ready");
        }
    }

    /// Remove a previously registered observer with exactly no arguments from this Dispatcher
    public static void RemoveListenerStrangeEvent(object evt, EmptyCallback callback)
    {
        if (strangeDispatcher != null)
        {
            strangeDispatcher.RemoveListener(evt, callback);
        }
        else
        {
            Debug.LogWarning("strangeDispatcher Not Ready");
        }
    }

    /// Remove a previously registered observer with exactly no arguments from this Dispatcher
    public static void RemoveListenerStrangeEvent(object evt, EventCallback callback)
    {
        if (strangeDispatcher != null)
        {
            strangeDispatcher.RemoveListener(evt, callback);
        }
        else
        {
            Debug.LogWarning("strangeDispatcher Not Ready");
        }
    }


    /// Returns true if the provided observer is already registered
    public static bool HasListenerStrangeEvent(object evt, EventCallback callback)
    {
        if (strangeDispatcher != null)
        {
            return strangeDispatcher.HasListener(evt, callback);
        }
        else
        {
            Debug.LogWarning("strangeDispatcher Not Ready");
        }
        return false;
    }
}
