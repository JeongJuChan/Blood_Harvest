using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineRef
{
    private static Dictionary<float, WaitForSeconds> _waitSecondsDict = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds GetWaitForSeconds(float time)
    {
        if (!_waitSecondsDict.ContainsKey(time))
            _waitSecondsDict.Add(time, new WaitForSeconds(time));

        return _waitSecondsDict[time];
    }
}
