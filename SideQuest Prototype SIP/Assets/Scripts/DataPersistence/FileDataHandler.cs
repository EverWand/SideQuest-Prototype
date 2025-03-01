using System.IO;    //Used for File Handling - Input/Output
using UnityEngine;  
using System;

/* Class for Handling File Data for Json Serialization */
public class FileDataHandler
{
    string dataDirPath = "";    //Path to the data directory
    string dataFileName = "";   //Name of the data file

    /*====| Constructor |====*/
    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;     //Set the data directory path
        this.dataFileName = dataFileName;   //Set the data file name
    }

    public AppData Load() {
        //Path.combine ensures a correct path is created for the file
        string fullPath = Path.Combine(dataDirPath, dataFileName);

        // Tracks the loaded data
        AppData loadedData = null;    

        //GAURD: Check if the file exists
        if (!File.Exists(fullPath)) { 
            Debug.LogError("Cannot find file path when loading Application Data"); 
            return null;  
        }
        
        string dataToLoad = ""; //For tracking file file data

        try
        {
            using (FileStream stream = new FileStream(fullPath, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    dataToLoad = reader.ReadToEnd();
                }
            }

            //Deserialize the data into C# object
            loadedData = JsonUtility.FromJson<AppData>(dataToLoad);
        }
        catch (Exception e)
        {
            Debug.LogError("Error loading file: " + e.Message);
        }


        return loadedData;
    }
    public void Save(AppData data) {
        //Path.combine ensures a correct path is created for the file
        string fullPath = Path.Combine(dataDirPath, dataFileName);

        //TRY: Save the data to the file
        try {
            //Create the directory if it does not exist
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //Serialize the data into a json string
            string jsonData = JsonUtility.ToJson(data, true);

            // Open the file stream
            using (FileStream stream = new FileStream(fullPath, FileMode.Create)) {
                //Write the json data to the file
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(jsonData); //Write the data to the file
                } 
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error saving file: " + e.Message);
        }
        Debug.Log("Saving to: " + fullPath);
    }
}
