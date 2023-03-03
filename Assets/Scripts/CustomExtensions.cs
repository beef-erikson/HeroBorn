/********************************
 * CustomExtensions.cs
 * Extends string.
 * Last Edit: 3-3-23
 * Troy Martin
 *
 * Public Methods:
 * public static void FancyDebug(this string str) - Counts the characters of the called string and writes to log.
 * 
 ********************************/

using UnityEngine;

public static class StringExtensions
{
    /// <summary>
    /// Counts the characters of the called string and writes to log.
    /// </summary>
    /// <param name="str">this string.</param>
    public static void FancyDebug(this string str)
    {
        Debug.Log($"This string contains {str.Length} characters.");
    }
}