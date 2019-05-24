using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputActionStateModel
{
    public InputActionStateModel(InputActionEnum inputAction, InputStateEnum inputState)
    {
        this.inputAction = inputAction;
        this.inputState = inputState;
    }

    private readonly InputActionEnum inputAction;
    private readonly InputStateEnum inputState;

    public InputActionEnum InputAction
    {
        get { return inputAction; }
    }

    public InputStateEnum InputState
    {
        get { return inputState; }
    }
}
