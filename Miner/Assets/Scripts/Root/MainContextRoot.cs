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

	    injectionBinder.Bind<IInputService>().To<InputService>().ToSingleton();

        injectionBinder.Unbind<ICommandBinder>(); //Unbind to avoid a conflict!
	    injectionBinder.Bind<ICommandBinder>().To<EventCommandBinder>().ToSingleton();

	    injectionBinder.Bind<IGameModel>().To<GameModel>().ToSingleton();
	    injectionBinder.Bind<IInputControlModel>().To<InputControlModel>().ToSingleton();

	    


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
            .To<InputServiceStartCommand>()
            .To<ConfigInputControlLoadCommand>()
            .To<ConfigGameLoadCommand>()
            .To<CameraMainAddCommand>()
            .To<PlayerCreationCommand>()
            .To<TilePoolCreateCommand>()
            .To<TileWorldHolderCreateCommand>()
            .To<RetainOneFrameCommand>()
            .To<UI_HUDCreateCommand>()
            .To<TileChestCreateCommand>()
            .To<WorldCreationAtFirstCommand>()
            .To<CameraMainStartFolowPlayerCommand>()
            //.To<TileRandomCreateCommand>()
            .Pooled()
            .InSequence()
            .Once();

        //////////////////////////////////////////////////////////////////////// Root

        // MainCamera

        mediationBinder.BindView<MainCameraView>().ToMediator<MainCameraMediator>();

        //

        /////////////////////////////////////////////////////////////////////// 

        ///////////////////////////////////////////////////////////////////////  Game

        // Player

        mediationBinder.BindView<PlayerView>().ToMediator<PlayerMediator>();

        commandBinder.Bind(RootEvents.E_PlayerCreate).To<PlayerCreationCommand>().Pooled();

        //

        // Tile

        mediationBinder.BindView<TileView>().ToMediator<TileMediator>();
        mediationBinder.BindView<TilePoolView>().ToMediator<TilePoolMediator>();
        mediationBinder.BindView<TileWorldHolderView>().ToMediator<TileWorldHolderMediator>();

        commandBinder.Bind(RootEvents.E_TileCreateRandom).To<TileRandomCreateCommand>().Pooled();
        commandBinder.Bind(RootEvents.E_TileWorldCreate).To<WorldCreationCommand>().Pooled();


        //

        // Resources

        commandBinder.Bind(RootEvents.E_ResourcesCreateRandom).To<ResourcesCreateRandomCommand>().Pooled();

        //


        /////////////////////////////////////////////////////////////////////// 

        /////////////////////////////////////////////////////////////////////// UI

        // HUD

        mediationBinder.BindView<UI_HUDView>().To<UI_HUDMediator>();
        mediationBinder.BindView<UI_InventoryCellView>().ToMediator<UI_InventoryCellMediator>();

        commandBinder.Bind(RootEvents.E_UI_HUDCreateCommand).To<UI_HUDCreateCommand>().Pooled();
        commandBinder.Bind(RootEvents.E_UI_HUDDestoryCommand).To<UI_HUDDestroyCommand>().Pooled();
        //


        ///////////////////////////////////////////////////////////////////////
    }
}
