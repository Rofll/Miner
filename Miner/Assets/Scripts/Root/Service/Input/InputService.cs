using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputServiceMonoBehaviour : MonoBehaviour
{

}

public class InputService : IInputService
{
    public static InputService instance;

    private InputServiceMonoBehaviour inputServiceMonoBehaviour = new InputServiceMonoBehaviour();

    ~InputService()
    {
        instance = null;
        inputServiceMonoBehaviour = null;
    }

    public InputService()
    {
        GameObject go = new GameObject("InputService");
        inputServiceMonoBehaviour = go.AddComponent<InputServiceMonoBehaviour>();
        instance = this;
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
}


