using UnityEngine;
using System.Collections.Generic;

public class SaveData : MonoBehaviour
{
    
    public void SaveToJson() {
        string saveData = JsonUtility.ToJson("");
        string filepath =  Application.persistentDataPath + "/SaveData.json";

        Debug.Log(filepath);
        //System.IO.File.WriteAllText(filepath, saveData);
        Debug.Log("Saved Successful");
    }
}
