using UnityEngine;
using System.Collections;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.mediation.api;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.dispatcher.eventdispatcher.api;

public class GameContextRoot : MVCSContext
{
    public GameContextRoot(MonoBehaviour contextView) : base(contextView, ContextStartupFlags.MANUAL_MAPPING)
    {
    }

    // CoreComponents
    protected override void addCoreComponents()
    {
        base.addCoreComponents();
    }

    // Commands and Bindings
    protected override void mapBindings()
    {
        base.mapBindings();
    }
}
