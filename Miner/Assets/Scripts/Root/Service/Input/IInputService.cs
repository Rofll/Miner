using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputService
{
    void InitInputService(IInputControlModel inputControlModel);

    void OnTap();
    void OnSwipe();
    void OnDrag();
    void OnZoom();
}
