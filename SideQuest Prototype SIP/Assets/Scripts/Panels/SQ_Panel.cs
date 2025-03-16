using UnityEngine;
using UnityEngine.Events;

public abstract class SQ_Panel : MonoBehaviour
{
    [SerializeField] public GameObject panelPrefab; //Prefab of the Panel

    /*====| Events |=====*/
    public UnityAction OnRemoved;   //When Panel is Being Removed
    public UnityAction OnCreated;   //When Panel is Created
    public UnityAction OnOpen;      //When Panel is Open
    public UnityAction OnClose;     //When Panel is Closed

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
    public virtual void Handle_OnBack()
    {
        GameManager.instance.GetComponent<PanelSwitcher>().GoBack();
    }
}
