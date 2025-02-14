using UnityEngine;
using UnityEngine.Events;

public abstract class SQ_Panel : MonoBehaviour
{
    [SerializeField] public GameObject panelPrefab;

    public UnityAction OnRemoved;
    public UnityAction OnCreated;
    public UnityAction OnOpen;
    public UnityAction OnClose;

    private void Awake()
    {
        if (panelPrefab == null)
        {
            panelPrefab = GetComponent<GameObject>();
        }

        //Subscribe handles to the Actions
        OnRemoved += Handle_OnRemoved;  //Removed
        OnCreated += Handle_OnCreated;  //Focused

        OnOpen += Handle_OnOpen;  //Open
        OnClose += Handle_OnClose;  //Close

        OnCreated?.Invoke();
    }

    protected virtual void Handle_OnCreated()
    {
        //Debug.Log(name + " is Focused");
    }

    protected virtual void Handle_OnRemoved()
    {
        //Debug.Log("Removing " + name);
        Destroy(gameObject); //Destroy Self
    }



    protected virtual void Handle_OnOpen()
    {
        gameObject.SetActive(true);
    }
    protected virtual void Handle_OnClose() { }
}
