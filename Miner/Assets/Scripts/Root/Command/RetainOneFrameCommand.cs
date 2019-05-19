using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetainOneFrameCommand : BaseCommand  
{
    public override void Execute()
    {
        Retain();
        CoroutineWorker.StarCoroutine(WaitForFrame());
    }

    IEnumerator WaitForFrame()
    {
        yield return null;
        Release();
    }
}
