using UnityEngine;

public class PersistentDataManager : MonoBehaviour
{
    public static PersistentDataManager instance { get; private set; }

    AppData appData; //Tracks Data for load and saving


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
        LoadAppData();
    }

    private void OnApplicationQuit()
    {
        SaveAppData();
    }


    public void SaveAppData()
    {
        // Save the data

    }

    public void LoadAppData()
    {
        if(appData == null)
        {
           Debug.Log("No app data to load");
        }
    }

    public void NewAppData() { 
        this.appData = new AppData();
    }
}
