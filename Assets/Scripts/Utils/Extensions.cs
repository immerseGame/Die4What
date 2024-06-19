using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    //STRINGS
    public static bool IsNullOrEmptyOrWhitespace(this string value)
    {
        return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
    }

    public static string GetRandomID(string prefix = "")
    {
        return $"{prefix}{Guid.NewGuid()}";
    }

    public static string FirstLetterUppercase(this string s)
    {
        char[] a = s.ToCharArray();
        a[0] = char.ToUpper(a[0]);
        return new string(a);
    }

    //NUMERICS

    public static float ConvertScales(float scale1Value, float scale1Min, float scale1Max, float scale2Min = 0, float scale2Max = 100)
    {
        return ((scale1Value - scale1Min) * (scale2Max - scale2Min) / (scale1Max - scale1Min)) + scale2Min;
    }

    public static float ConvertScales(this int scale1Value, float scale1Min, float scale1Max, float scale2Min = 0, float scale2Max = 100)
    {
        return ConvertScales(scale1Value, scale1Min, scale1Max, scale2Min, scale2Max);
    }

    public static bool IntToBool(int value)
    {
        return Convert.ToBoolean(value);
    }

    public static int BoolToInt(bool value)
    {
        return Convert.ToInt32(value);
    }

    public static bool IsPair(this int value)
    {
        return value % 2 == 0;
    }

    public static bool IsPair(this float value)
    {
        return value % 2 == 0;
    }

    public static bool IsMultiple(this int value, float num)
    {
        return value % num == 0;
    }

    public static bool IsMultiple(this float value, float num)
    {
        return value % num == 0;
    }

    //ARRAYS / LISTS


    public static T GetRandomElement<T>(T[] array)
    {
        return RandomUtils.FromArray(array);
    }

    public static T GetRandomElement<T>(this List<T> array)
    {
        return RandomUtils.FromArray(array);
    }

    public static int GetRandomIndex<T>(T[] array)
    {
        return RandomUtils.ArrayIndex(array);
    }

    public static int GetRandomIndex<T>(this List<T> array)
    {
        return RandomUtils.ArrayIndex(array);
    }

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }



}
