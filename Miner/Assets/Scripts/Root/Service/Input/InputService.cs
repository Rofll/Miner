using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputServiceMonoBehaviour : MonoBehaviour
{
    private InputService inputService;
    private IInputControlModel inputControlModel;

    public void Init(InputService inputService, IInputControlModel inputControlModel)
    {
        this.inputService = inputService;
        this.inputControlModel = inputControlModel;
    }

    private void Update()
    {
        for (int i = 1; i < (int)InputActionEnum.End; i++)
        {
            KeyCode key = inputControlModel.GetInputKey((InputActionEnum)i);

            if (Input.GetKeyDown(key))
            {
                inputService.OnKey(new InputActionStateModel((InputActionEnum)i, InputStateEnum.Down));
            }

            else if (Input.GetKey(key))
            {
                inputService.OnKey(new InputActionStateModel((InputActionEnum)i, InputStateEnum.Hold));
            }

            else if (Input.GetKeyUp(key))
            {
                inputService.OnKey(new InputActionStateModel((InputActionEnum)i, InputStateEnum.Up));
            }
        }
    }
}

public class InputService : IInputService
{
    public static InputService instance;

    private IInputControlModel inputControlModel;

    private InputServiceMonoBehaviour inputServiceMonoBehaviour;

    ~InputService()
    {
        instance = null;
        inputServiceMonoBehaviour = null;
        inputControlModel = null;
    }

    public InputService()
    {
       
    }

    public void InitInputService(IInputControlModel inputControlModel)
    {
        instance = this;

        GameObject go = new GameObject("InputService");
        inputServiceMonoBehaviour = go.AddComponent<InputServiceMonoBehaviour>();
        inputServiceMonoBehaviour.Init(instance, inputControlModel);

        GameObject.DontDestroyOnLoad(go);
    }

    public void OnTap()
    {

    }

    public void OnSwipe()
    {

    }

    public void OnDrag()
    {

    }

    public void OnZoom()
    {

    }

    public void OnKey(InputActionStateModel inputActionStateModel)
    {
        MainContextView.DispatchStrangeEvent(RootEvents.E_InputOnKey, inputActionStateModel);
    }

}


