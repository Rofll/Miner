using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputService
{
    void OnTap();
    void OnSwipe();
    void OnDrag();
    void OnZoom();
}
