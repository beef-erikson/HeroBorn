using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour, IManager
{
    private string _state;
    private string _dataPath;
    
    public string State { get; set; }

    private void Awake()
    {
        _dataPath = Application.persistentDataPath + "/Player_Data/";
        Debug.Log(_dataPath);
    }

    // Start is called before the first frame update
    private void Start()
    {
        Initialize();
    }

    /// <summary>
    /// Runs FilesystemInfo()
    /// </summary>
    public void Initialize()
    {
        _state = "Data Manager initialized...";
        Debug.Log(_state);

        FilesystemInfo();
    }

    private static void FilesystemInfo()
    {
        Debug.Log($"Path separator character: {Path.PathSeparator}");
        Debug.Log($"Directory separator character: {Path.DirectorySeparatorChar}");
        Debug.Log($"Current directory: {Directory.GetCurrentDirectory()}");
        Debug.Log($"Temporary path: {Path.GetTempPath()}");
    }
}
