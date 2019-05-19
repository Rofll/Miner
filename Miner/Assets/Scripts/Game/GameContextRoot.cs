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
using strange.extensions.injector.impl;

public class GameContextRoot : MVCSContext
{
    public GameContextRoot(MonoBehaviour view) : base(view)
    {
    }

    public GameContextRoot(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
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

        mediationBinder.Bind<TileView>().To<TileMediator>();

        crossContextBridge.Bind(RootEvents.E_TileCreateSpecific);

        commandBinder.Bind(RootEvents.E_TileCreateSpecific).To<TileConcreteCreateCommand>();
    }
}
