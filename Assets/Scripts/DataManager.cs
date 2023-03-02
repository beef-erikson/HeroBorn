using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;        
using UnityEngine;

public class DataManager : MonoBehaviour, IManager
{
    private string _state;
    private string _dataPath;
    private string _textFile;
    private string _streamingTextFile;
    
    public string State { get; set; }
    
    // Awake is called before start
    private void Awake()
    {
        _dataPath = Application.persistentDataPath + "/Player_Data/";
        Debug.Log(_dataPath);
        
        _textFile = _dataPath + "Save_Data.txt";
        _streamingTextFile = _dataPath + "Streaming_Save_Data.txt";
    }

    // Start is called before the first frame update
    private void Start()
    {
        Initialize();
    }

    /// <summary>
    /// Creates directory "Player_Data" if not already present.
    /// </summary>
    public void Initialize()
    {
        _state = "Data Manager initialized...";
        Debug.Log(_state);
        
        
        FilesystemInfo();
        NewDirectory();
        WriteToStream(_streamingTextFile);
        
        // Using regular file operations
        //NewTextFile();
        //UpdateTextFile();
        //ReadFromFile(_textFile);
    }
    
    /// <summary>
    /// Logs various directory info
    /// </summary>
    private static void FilesystemInfo()
    {
        Debug.Log($"Path separator character: {Path.PathSeparator}");
        Debug.Log($"Directory separator character: {Path.DirectorySeparatorChar}");
        Debug.Log($"Current directory: {Directory.GetCurrentDirectory()}");
        Debug.Log($"Temporary path: {Path.GetTempPath()}");
    }

    /// <summary>
    /// Creates directory specified in _dataPath, if not already present.
    /// </summary>
    private void NewDirectory()
    {
        if (Directory.Exists(_dataPath))
        {
            Debug.Log("Directory already exists...");
            return;
        }

        Directory.CreateDirectory(_dataPath);
        Debug.Log($"New directory created at {_dataPath}");
    }

    /// <summary>
    /// Recursively deletes _dataPath, if present.
    /// </summary>
    private void DeleteDirectory()
    {
        if (!Directory.Exists(_dataPath))
        {
            Debug.Log("Directory doesn't exist or has already been deleted...");
            return;
        }
        
        Directory.Delete(_dataPath, true);
        Debug.Log($"Directory {_dataPath} successfully deleted.");
    }

    /// <summary>
    /// Creates _textFile in directory _dataPath with header.
    /// </summary>
    private void NewTextFile()
    {
        if (File.Exists(_textFile))
        {
            Debug.Log("File already exists...");
            return;
        }
        
        File.WriteAllText(_textFile, "<SAVE DATA>\n");
        Debug.Log("New file created!");
    }

    /// <summary>
    /// Appends _textFile with time of game starting.
    /// </summary>
    private void UpdateTextFile()
    {
        if (!File.Exists(_textFile))
        {
            Debug.Log("File Doesn't exist...");
            return;
        }
        
        File.AppendAllText(_textFile, $"Game started: {DateTime.Now}\n");
        Debug.Log("File updated successfully!");
    }

    /// <summary>
    /// Writes to Debug.Log contents of file.
    /// </summary>
    /// <param name="filename">File to print to Debug.Log</param>
    private static void ReadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Debug.Log("File doesn't exist...");
            return;
        }
        
        Debug.Log(File.ReadAllText(filename));
    }

    /// <summary>
    /// Deletes the supplied filename, if it exists.
    /// </summary>
    /// <param name="filename">Filename to delete.</param>
    private void DeleteFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Debug.Log("File doesn't exist or has already been deleted...");
            return;
        }
        
        File.Delete(_textFile);
        Debug.Log("File successfully deleted!");
    }

    /// <summary>
    /// Creates and adds header file from provided filename.
    /// Appends a game ended message with DateTime.Now.
    /// </summary>
    /// <param name="filename">File to write to.</param>
    private static void WriteToStream(string filename)
    {
        if (!File.Exists(filename))
        {
            var newStream = File.CreateText(filename);
            
            newStream.WriteLine("<Save Data> for HERO BORN \n");
            newStream.Close();
            Debug.Log("New file created with StreamWriter!");
        }

        var streamWriter = File.AppendText(filename);
        
        streamWriter.WriteLine($"Game ended: {DateTime.Now}");
        streamWriter.Close();
        Debug.Log("File contents updated with StreamWriter");
    }
}
