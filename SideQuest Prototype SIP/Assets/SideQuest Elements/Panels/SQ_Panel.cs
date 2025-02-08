using UnityEngine;
using UnityEngine.Events;

public abstract class SQ_Panel : MonoBehaviour
{
    [SerializeField] public GameObject panelPrefab { get; private set; }

    public UnityAction OnRemoved;
    public UnityAction OnCreated;

    private void Awake()
    {
        if (panelPrefab == null) { 
            panelPrefab = GetComponent<GameObject>();
        }

        //Subscribe handles to the Actions
        OnRemoved += Handle_OnRemoved;  //Removed
        OnCreated += Handle_OnFocused;  //Focused
    }


    protected virtual void Handle_OnRemoved() {
        Debug.Log("Removing " + name);
        Destroy(gameObject); //Destroy Self
    }

    protected virtual void Handle_OnFocused() {
        Debug.Log(name + " is Focused");
    }
}
