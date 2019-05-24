using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputServiceStartCommand : BaseCommand
{
    [Inject]
    public IInputService InputService { get; set; }

    [Inject]
    public IInputControlModel InputControlModel { get; set; }

    public override void Execute()
    {
        InputService.InitInputService(InputControlModel);
    }
}
