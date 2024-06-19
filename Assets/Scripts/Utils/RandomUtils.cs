using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomUtils
{
    public static T FromArray<T>(T[] array)
    {
        return array[UnityEngine.Random.Range(0, array.Length)];
    }

    public static T FromArray<T>(List<T> array)
    {
        return array[UnityEngine.Random.Range(0, array.Count)];
    }

    public static int ArrayIndex<T>(T[] array)
    {
        return UnityEngine.Random.Range(0, array.Length);
    }

    public static int ArrayIndex<T>(List<T> array)
    {
        return UnityEngine.Random.Range(0, array.Count);
    }

    public static bool ExBool(float chanceOfTrue = .5f)
    {
        return UnityEngine.Random.Range(0f, 1f) <= chanceOfTrue;
    }
}
