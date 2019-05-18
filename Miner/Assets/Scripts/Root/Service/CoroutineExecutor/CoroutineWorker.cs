using UnityEngine;
using System.Collections;
using System;


//public class  

public class CoroutineWorkerMonoBehaviour : MonoBehaviour
{

}

public class CoroutineWorker : ICoroutineWorker
{
    public static CoroutineWorker instance;

    private MonoBehaviour coroutineWorker;
    ~CoroutineWorker()
    {
        instance = null;
        coroutineWorker = null;
    }
    public CoroutineWorker()
    {
        var go = new GameObject("CoroutineWorker");
        coroutineWorker = go.AddComponent<CoroutineWorkerMonoBehaviour>();
        instance = this;
        GameObject.DontDestroyOnLoad(go);
    }

    public Coroutine StarCoroutine(IEnumerator coroutine)
    {
        return coroutineWorker.StartCoroutine(coroutine);
    }

    public void StopCoroutine(Coroutine coroutine)
    {
        coroutineWorker.StopCoroutine(coroutine);
    }

    public void StopAllCoroutines()
    {
        coroutineWorker.StopAllCoroutines();
    }
}
