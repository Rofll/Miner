using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InputControlConfig", menuName = "Configs/InputControlConfig", order = 2)]
public class InputControlConfigScriptableObject : ScriptableObject
{
    [Header("Action Bind Key")]
    [SerializeField]

    private List<InputActionModel> binds = new List<InputActionModel>();

    public InputActionModel[] Binds
    {
        get
        {
            InputActionModel [] bindsCopy = new InputActionModel[binds.Count];
            binds.CopyTo(bindsCopy);

            return bindsCopy;
        }
    }
}
