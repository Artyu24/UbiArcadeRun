using System;
using UnityEngine;

public class DebugHelper
{
    public static bool IsNull<T>(T componentToCheck, string objectName, string className)
    {
        if (componentToCheck == null)
            Debug.LogWarning($"{className} inside '{objectName}' gameObject is missing a {typeof(T)}");

        return componentToCheck != null;
    }
}
