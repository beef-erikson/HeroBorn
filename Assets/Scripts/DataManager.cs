using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour, IManager
{
    private string _state; 
    
    public string State { get; set; }
    
    // Start is called before the first frame update
    private void Start()
    {
        Initialize();
    }

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
