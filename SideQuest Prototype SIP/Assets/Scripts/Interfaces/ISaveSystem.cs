using UnityEngine;

public interface ISaveSystem
{
    public string SaveData<T>(T data) {
        string savePrint = "";

        Debug.Log("Saving Data: " + savePrint);
        return savePrint;
    }

    public string LoadData<T>(T data)
    {
        string savePrint = "";

        Debug.Log("Loading Data: " + savePrint);
        return savePrint;
    }

    public void DataOverWrite<T>(T data) { 

    }
}
