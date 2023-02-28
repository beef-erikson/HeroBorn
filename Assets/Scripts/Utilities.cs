using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class Utilities
{
    public static int playerDeaths = 0;

    public static string UpdateDeathCount(ref int countReference)
    {
        countReference += 1;
        return $"Next time you'll be at number {countReference}";
    }
    
    /// <summary>
    /// Loads scene at index 0.
    /// </summary>
    public static void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    /// <summary>
    /// Loads the scene based on the provided scene index.
    /// </summary>
    /// <param name="sceneIndex">Index of scene to load.</param>
    /// <returns></returns>
    public static bool RestartLevel(int sceneIndex)
    {
        var message = UpdateDeathCount(ref playerDeaths);
        Debug.Log($"You've died {playerDeaths} times.");
        Debug.Log(message);
        
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1.0f;
        return true;
    }
}
