using UnityEngine;
using System.Collections;


public class AppLoadCommand : BaseCommand
{
	public static bool isNormalStart = true;

    public override void Execute()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        if (isNormalStart)
        {
            dispatcher.Dispatch(RootEvents.E_AppStartNormal);
        }

        else
        {
            dispatcher.Dispatch(RootEvents.E_AppStartDebug);
        }
    }
}
