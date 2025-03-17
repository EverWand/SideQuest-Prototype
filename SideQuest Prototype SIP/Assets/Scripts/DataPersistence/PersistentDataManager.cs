using CustomUtil;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PersistentDataManager : MonoBehaviour
{
    public static PersistentDataManager instance { get; private set; } //singleton instance

    AppData appData; //Tracks Data for load and saving

    [Header("File Storage Configs")]                    /*=====| File Storage Configs |=====*/
    [SerializeField] string fileName = "appData.json";  // Name of the file to save and load data
    List<ISaveData> dataPersistenceObjs;                // List of objects that implement ISaveData
    FileDataHandler dataHandler;                        // File Data Handler

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        //Set up the file data handler based on the file path and name
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        //Grab save data from project
        this.dataPersistenceObjs = FindAllSaveDataObjects();

        LoadAppData();  //Load the data
    }

    private void OnApplicationQuit()
    {
        SaveAppData();
    }

    public void NewAppData() {
        this.appData = new AppData();
    }

    public void SaveAppData()
    {
        // Pass the data to the save data objects
        foreach (ISaveData dataPersistenceObj in dataPersistenceObjs)
        {
            dataPersistenceObj.SaveData(ref appData);
        }

        // Save the data to the file
        dataHandler.Save(appData);
    }

    public void LoadAppData()
    {
        // Load the saved data from the data file
        this.appData = dataHandler.Load();
        //CHECK: No data found -> Create a new data object
        if (this.appData == null)
        {
            NewAppData(); //Create a new data object
        }

        //Load the data into the save data objects
        foreach (ISaveData dataPersistenceObj in dataPersistenceObjs)
        {
            dataPersistenceObj.LoadData(appData);
        }
    }

    List<ISaveData> FindAllSaveDataObjects()
    {
        //Get and Cast the objects of ISaveData
        IEnumerable<ISaveData> saveDataInstances = FindObjectsByType(typeof(GameObject), FindObjectsSortMode.None).OfType<ISaveData>();

        return new List<ISaveData>(saveDataInstances); // Return the list of ISaveData objects
    }
}
