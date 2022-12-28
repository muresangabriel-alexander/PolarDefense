using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityHelpers : MonoBehaviour
{
    /// <summary>
    /// suspends execution of thread for seconds
    /// </summary>
    /// <param name="seconds"></param>
    /// <returns></returns>
    public static IEnumerator waitSeconds(int seconds)
    {
        print("Begin wait() " + Time.time);
        yield return new WaitForSecondsRealtime(seconds);
        print("end wait() " + Time.time);
    }
}
