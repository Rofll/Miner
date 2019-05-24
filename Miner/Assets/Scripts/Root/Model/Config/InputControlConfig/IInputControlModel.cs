using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputControlModel
{
    void Init(Dictionary<InputActionEnum, KeyCode> inputBind);
    void Init(InputActionModel[] inputBind);
    void Bind(InputActionEnum inputAction, KeyCode key);
    KeyCode GetInputKey(InputActionEnum inputAction);
}
