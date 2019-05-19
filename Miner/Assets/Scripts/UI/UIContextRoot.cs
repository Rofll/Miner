﻿using UnityEngine;
using System.Collections;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.mediation.api;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.dispatcher.eventdispatcher.api;

public class UIContextRoot : MVCSContext
{
    public UIContextRoot(MonoBehaviour view) : base(view)
    {
    }

    public UIContextRoot(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
    {
    }

    // CoreComponents
    protected override void addCoreComponents()
    {
        base.addCoreComponents();

        injectionBinder.Bind<ICoroutineWorker>().To<CoroutineWorker>().ToSingleton();

        injectionBinder.Unbind<ICommandBinder>(); //Unbind to avoid a conflict!
        injectionBinder.Bind<ICommandBinder>().To<EventCommandBinder>().ToSingleton();
    }

    // Commands and Bindings
    protected override void mapBindings()
    {
        //base.mapBindings();
    }
}
