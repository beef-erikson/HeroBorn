using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class Utilities
{
    public static int playerDeaths = 0;

    /// <summary>
    /// Restarts the level, loading scene at index 0
    /// </summary>
    public static void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
}
