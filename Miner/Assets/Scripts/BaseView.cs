using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.context.api;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public abstract class BaseView : View
{
	[Inject( ContextKeys.CONTEXT_DISPATCHER )]
	public IEventDispatcher dispatcher { get; set;}

    [Inject]
    public ICoroutineWorker CoroutineWorker { get; set; }

    [Inject]
    public IGameModel GameModel { get; set; }

    [Inject]
    public IInputControlModel ControlModel { get; set; }


    public abstract void OnRegister();
    public abstract void OnRemove();

    public void AddListenerToButton( Button button, UnityAction call )
	{
		if( button != null )
		{
			button.onClick.RemoveAllListeners();
			button.onClick.AddListener( call );
		}
		else
		{
		    Debug.LogError( "Button - NULL" );
		}
	}

	public void AddListenerToToggle( Toggle button, UnityAction<bool> call )
	{
		if( button != null )
		{
			button.onValueChanged.RemoveAllListeners();
			button.onValueChanged.AddListener( call );
		}
		else
		{
			Debug.LogError( "Button - NULL" );
		}
	}


}