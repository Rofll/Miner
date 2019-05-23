using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMainStartFolowPlayerCommand : BaseCommand
{
    public override void Execute()
    {
        dispatcher.Dispatch(RootEvents.E_CameraMainStartFolowPlayer);
    }
}
