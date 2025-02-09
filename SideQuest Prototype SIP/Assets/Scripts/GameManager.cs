using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    List<Task> savedTasks = new List<Task>();
    [SerializeField] PanelSwitcher panelSwitcher;


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

        if (panelSwitcher == null) { panelSwitcher = GetComponent<PanelSwitcher>(); }
    }
}
