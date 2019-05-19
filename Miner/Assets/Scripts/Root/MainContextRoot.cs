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

public class MainContextRoot : MVCSContext
{
    public MainContextRoot(MonoBehaviour view) : base(view)
    {
    }

    public MainContextRoot(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
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

        // System Commands
        commandBinder.Bind(ContextEvent.START).To<AppLoadCommand>().Pooled().InSequence().Once();
        // Normal Start
        commandBinder.Bind(RootEvents.E_AppStartNormal)
#if UNITY_IOS || UNITY_IPHONE
#elif UNITY_ANDROID
#elif UNITY_EDITOR
#endif
            .To<RetainOneFrameCommand>()
            .To<MainCameraAddCommand>()
            .To<TileCreateCommand>()
            .Pooled()
            .InSequence()
            .Once();

        // Root
        mediationBinder.BindView<MainCameraView>().ToMediator<MainCameraMediator>();
        //

        // Game
        mediationBinder.BindView<TileView>().ToMediator<TileMediator>();
        //

        // UI

        //
    }
}
