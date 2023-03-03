/********************************
 * DataManager.cs
 * Various data management strategies using Text, StreamReader/Writer, JSON and XML.
 * Last Edit: 3-3-23
 * Troy Martin
 *
 * Public Methods:
 * public void Initialize() - Data access methods are ran here.
 * 
 * Private Methods:
 * private static void FilesystemInfo() - Logs various directory info.
 * private void NewDirectory() - Creates directory specified in _dataPath, if not present.
 * private void DeleteDirectory() - Recursively deletes directory specified in _dataPath.
 * private void NewTextFile() - Creates _textFile in _dataPath with a header, if not present.
 * private void WriteToTextFile() - Appends _textFile with time of game starting.
 * private static void WriteToStream(string filename) - Writes header if not present and appends game start.
 * private void WriteToXml(string filename) - Writes dummy info to XML file.
 * private static void ReadFromFile(string filename) - Writes to Debug.Log contents of file.
 * private static void ReadFromStream(string filename) - Writes to Debug.Log contents of file using StreamReader.
 * private void DeleteFile(string filename) - Deletes filename, if it exists.
 * private void SerializeXML() - Serializes list of weapons into an XML file.
 * private void DeserializeXML() - Deserializes list of weapon from XML and outputs to Debug.Log.
 * private void SerializeJson() - Serializes inventory into a JSON file.
 * private void DeserializeJson() - Deserializes _jsonWeapons and outputs to Debug.Log.
 * 
 ********************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class DataManager : MonoBehaviour, IManager
{
    public string State { get; set; }
    private string _state;
    private string _dataPath;
    private string _textFile;
    private string _streamingTextFile;
    private string _xmlLevelProgress;
    private string _xmlWeapons;
    private string _jsonWeapons;
    
    private readonly List<Weapon> _weaponInventory = new List<Weapon>
    {
        new Weapon("Sword of Doom", 100),
        new Weapon("Butterfly Knives", 25),
        new Weapon("Brass Knuckles", 15),
    };

    // Awake is called before start
    private void Awake()
    {
        _dataPath = Application.persistentDataPath + "/Player_Data/";
        Debug.Log(_dataPath);
        
        //_textFile = _dataPath + "Save_Data.txt";
        //_streamingTextFile = _dataPath + "Streaming_Save_Data.txt";
        //_xmlLevelProgress = _dataPath + "Progress_Data.xml";
        //_xmlWeapons = _dataPath + "WeaponInventory.xml";
        _jsonWeapons = _dataPath + "WeaponJSON.json";
    }

    // Start is called before the first frame update
    private void Start()
    {
        Initialize();
    }

    /// <summary>
    /// Data access methods are ran here.
    /// </summary>
    public void Initialize()
    {
        _state = "Data Manager initialized...";
        Debug.Log(_state);
        
        FilesystemInfo();
        NewDirectory();
        SerializeJson();
        DeserializeJson();
        
        // Using regular file operations
        //NewTextFile();
        //WriteToTextFile();
        //ReadFromFile(_textFile);
        
        // Using Streams
        //WriteToStream(_streamingTextFile);
        //ReadFromStream(_streamingTextFile);
        //WriteToXML(_xmlLevelProgress);
        //ReadFromStream(_xmlLevelProgress);
        
        // Serialization of XML
        //SerializeXML();
        //DeserializeXML();
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
    private void WriteToTextFile()
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
    /// Creates and adds header file from provided filename.
    /// Appends a game ended message with DateTime.Now.
    /// </summary>
    /// <param name="filename">File to write to.</param>
    private static void WriteToStream(string filename)
    {
        // Creates file and header if not present
        if (!File.Exists(filename))
        {
            using var newStream = File.CreateText(filename);
            newStream.WriteLine("<Save Data> for HERO BORN \n");
            
            Debug.Log("New file created with StreamWriter!");
        }

        // Appends Game ended message
        using var streamWriter = File.AppendText(filename);
        streamWriter.WriteLine($"Game ended: {DateTime.Now}");
        
        Debug.Log("File contents updated with StreamWriter");
    }

    /// <summary>
    /// Writes dummy info to XML file.
    /// </summary>
    /// <param name="filename">XML file to create.</param>
    private void WriteToXML(string filename)
    {
        // Do nothing if file exists
        if (File.Exists(filename)) return;
        
        using var xmlStream = File.Create(filename);
        using var xmlWriter = XmlWriter.Create(xmlStream);
        xmlWriter.WriteStartDocument();
        xmlWriter.WriteStartElement("level_progress");
        for (var i = 1; i < 5; i++)
        {
            xmlWriter.WriteElementString("level", "Level-" + i);
        }
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
    /// Writes provided file contents via StreamReader to Debug.Log, if present.
    /// </summary>
    /// <param name="filename">File to read.</param>
    private static void ReadFromStream(string filename)
    {
        if (!File.Exists(filename))
        {
            Debug.Log("File doesn't exist...");
            return;
        }

        using var streamReader = new StreamReader(filename);
        Debug.Log(streamReader.ReadToEnd());
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
    /// Serializes list of weapons into an XML file.
    /// </summary>
    private void SerializeXML()
    {
        var xmlSerializer = new XmlSerializer(typeof(List<Weapon>));

        using var stream = File.Create(_xmlWeapons);
        xmlSerializer.Serialize(stream, _weaponInventory);
    }

    /// <summary>
    /// Deserializes XML file and outputs to Debug.Log.
    /// </summary>
    private void DeserializeXML()
    {
        // If there's no weapons XML file, do nothing
        if (!File.Exists(_xmlWeapons)) return;
        
        var xmlSerializer = new XmlSerializer(typeof(List<Weapon>));

        using var stream = File.OpenRead(_xmlWeapons);
        var weapons = (List<Weapon>)xmlSerializer.Deserialize(stream);
        foreach (var weapon in weapons)
        {
            Debug.Log($"Weapon: {weapon.name} - Damage: {weapon.damage}");
        }
    }

    /// <summary>
    /// Serializes inventory into JSON file.
    /// </summary>
    private void SerializeJson()
    {
        var shop = new WeaponShop
        {
            inventory = _weaponInventory
        };

        var jsonString = JsonUtility.ToJson(shop, true);

        using var stream = File.CreateText(_jsonWeapons);
        stream.WriteLine(jsonString);
    }

    /// <summary>
    /// Deserializes _jsonWeapons and outputs to Debug.Log.
    /// </summary>
    private void DeserializeJson()
    {
        if (!File.Exists(_jsonWeapons)) return;
        
        using var stream = new StreamReader(_jsonWeapons);
        var jsonString = stream.ReadToEnd();
        var weaponData = JsonUtility.FromJson<WeaponShop>(jsonString);
            
        foreach (var weapon in weaponData.inventory)
        {
            Debug.Log($"Weapon: {weapon.name} - Damage: {weapon.damage}");    
        }
    }
}
