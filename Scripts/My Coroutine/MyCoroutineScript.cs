using UnityEngine;
using System.Collections;

public static class MyCoroutineScript {

    public static IEnumerator WaitForRealSeconds(float time)
    {
        //The time since we clicked the "Play" button on our game.
        float start = Time.realtimeSinceStartup;

        while (Time.realtimeSinceStartup < (start + time))
        {
            yield return null;
        }
    }
}
