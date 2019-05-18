using System.Collections;

public interface ICoroutineWorker
{

	UnityEngine.Coroutine StarCoroutine( IEnumerator coroutine );

	void StopCoroutine( UnityEngine.Coroutine coroutine );

    void StopAllCoroutines();
}
