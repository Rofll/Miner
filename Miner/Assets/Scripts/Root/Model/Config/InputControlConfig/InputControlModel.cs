using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputControlModel : IInputControlModel
{
    public InputControlModel()
    {
        inputBind = new Dictionary<InputActionEnum, KeyCode>();
    }

    public InputControlModel(Dictionary<InputActionEnum, KeyCode> inputBind)
    {
        this.inputBind = inputBind;
    }

    private Dictionary<InputActionEnum, KeyCode> inputBind;

    public void Init(Dictionary<InputActionEnum, KeyCode> inputBind)
    {
        this.inputBind = inputBind;
    }

    public void Init(InputActionModel[] inputBind)
    {
        this.inputBind = new Dictionary<InputActionEnum, KeyCode>();

        foreach (InputActionModel inputActionModel in inputBind)
        {
            char keyChar = char.ToUpper(inputActionModel.key);

            KeyCode key = KeyCode.None;

            bool isParseSucced =  System.Enum.TryParse(keyChar.ToString(), out key);

            if (isParseSucced)
                this.inputBind.Add(inputActionModel.inputAction, key);
        }
    }

    public void Bind(InputActionEnum inputAction, KeyCode key)
    {
        if (inputBind == null)
        {
            inputBind = new Dictionary<InputActionEnum, KeyCode>();
        }

        if (inputBind.ContainsKey(inputAction))
        {
            inputBind[inputAction] = key;
        }

        else
        {
            inputBind.Add(inputAction, key);
        }
    }

    public KeyCode GetInputKey(InputActionEnum inputAction)
    {
        if (inputBind != null)
        {
            if (inputBind.ContainsKey(inputAction))
            {
                if (inputBind[inputAction] == KeyCode.None)
                {
                    Debug.Log("There is no Key bind to: " + inputAction.ToString());
                }

                return inputBind[inputAction];
            }

            else
            {
                Debug.Log("There is no Key bind to: " + inputAction.ToString());
                return KeyCode.None;
            }
        }

        Debug.LogError("inputBind == NULL");
        return KeyCode.None;
    }
}
