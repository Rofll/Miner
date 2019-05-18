﻿/*
 * @ name: BaseCommand for Strange IOC
 * @ author: Andrey Sidorov ( Sky-Fox ) https://linkedin.com/in/skyfox
 * @ All rights reserved / Todos los derechos reservados / Âñå ïðàâà ñîõðàíåíû
*/

using System;
using UnityEngine;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.command.impl;
using strange.extensions.pool.api;
using strange.extensions.mediation.api;
using strange.extensions.mediation.impl;

public class BaseCommand : EventCommand
{
	[Inject( ContextKeys.CONTEXT_DISPATCHER )]
	public IEventDispatcher dispatcher { get; set; }

	[Inject]
	public IEvent eventData { get; set; }

    [Inject]
    public ICoroutineWorker CoroutineWorkero { get; set; }

    public override void Execute()
    {
        
    }

    public override void Retain()
	{
		base.Retain();
	}

	public override void Release()
	{
		base.Release();
	}
}

