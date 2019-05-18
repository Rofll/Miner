using System;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

namespace strange.extensions.mediation.impl
{
    public class BaseMediator : Mediator
    {
	    [Inject( ContextKeys.CONTEXT_DISPATCHER )]
	    public IEventDispatcher dispatcher { get; set; }


        public override void PreRegister()
        {
            base.PreRegister();
        }


        public override void OnRegister()
	    {
		    base.OnRegister();

	    }

	    public override void OnRemove()
	    {
		    base.OnRemove();
	    }

        public override void OnEnabled()
        {
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
        }
    }
}