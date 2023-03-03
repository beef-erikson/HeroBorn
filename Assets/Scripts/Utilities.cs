using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class Utilities
{
    private static int _playerDeaths = 0;

    private static string UpdateDeathCount(ref int countReference)
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
        if (sceneIndex < 0)
        {
            throw new System.ArgumentException("Scene index cannot be negative.");
        }
        
        var message = UpdateDeathCount(ref _playerDeaths);
        Debug.Log($"You've died {_playerDeaths} times.");
        Debug.Log(message);
        
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1.0f;
        return true;
    }
}
