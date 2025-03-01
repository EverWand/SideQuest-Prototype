using UnityEngine;
using UnityEngine.Events;

public class PanelSwitcher : MonoBehaviour
{
    [SerializeField] Transform switcherRoot;
    [SerializeField] SQ_Panel rootPanel;


    //[THIS STUFF IS JUST FOR THE INSPECTOR FOR DEBUGGING]
    [SerializeField] private SQ_Panel _currPanel;
    [SerializeField] private SQ_Panel _prevPanel;

    public SQ_Panel currPanel { get => _currPanel; private set => _currPanel = value; }
    public SQ_Panel prevPanel { get => _prevPanel; private set => _prevPanel = value; }

    [SerializeField] SQ_Panel[] PanelTypes;

    public UnityAction OnBack;

    private void Start()
    {
        //Fill PanelType List [via Resource Folder]
        PanelTypes = Resources.LoadAll<SQ_Panel>("UI_Panels");

        if (rootPanel == null)
        {
            //set the root panel [via Resorce Folder]
            rootPanel = Resources.Load<SQ_Panel>("UI_Panels/RootPanel");

        }
    }

    /*Generic Method That will switch to a specific type of Panel if it exists*/
    public SQ_Panel SwitchPanel<T>() where T : SQ_Panel
    {
        //Go through Each Panel
        foreach (SQ_Panel panel in PanelTypes)
        {
            //Check if the panel is the same type as requested panel Type
            if (panel is T)
            {
                return SwitchPanel(panel);
            }
        }
        return null;
    }

    public void SwitchPanel(int index)
    {
        if (PanelTypes.Length - 1 > index || index < 0)
        {
            Debug.LogError("Index Out of Range of " + gameObject.name + " Panel List.");
            return;
        }

        SwitchPanel(PanelTypes[index]);
    }

    SQ_Panel SwitchPanel(SQ_Panel panel)
    {
        if (panel == null) { return null; }

        if (prevPanel != null)
        {
            prevPanel.OnRemoved?.Invoke();
        }

        prevPanel = currPanel; // Track the previous panel

        if (prevPanel != null)
        {
            prevPanel.gameObject.SetActive(false); // Deactivate previous panel
            prevPanel.OnClose?.Invoke();
        }

        // If the panel does not exist, create a new one
        currPanel = CreatePanel(panel.panelPrefab);
        currPanel.gameObject.SetActive(true);
        currPanel.OnOpen?.Invoke();

        return currPanel;
    }
    public void FocusRootPanel()
    {
        //CHECK: Root is not set
        if (rootPanel == null)
        {
            //Make the first panel in list of panels the Root otherwise continue as null
            rootPanel = PanelTypes[0] != null ? PanelTypes[0] : null;
        }

        //GAURD: No Root Available
        if (rootPanel == null) { return; }

        //Found Root, Switch to that Panel
        SwitchPanel(rootPanel);

    }

    SQ_Panel CreatePanel(GameObject panelObj)
    {
        SQ_Panel newPanel = Instantiate(panelObj, switcherRoot).GetComponent<SQ_Panel>();

        return newPanel;
    }

    public SQ_Panel GoBack()
    {
        if (prevPanel == null) { return null; }

        OnBack?.Invoke();

        SQ_Panel tempPanel = prevPanel;
        prevPanel = currPanel;
        currPanel = tempPanel;

        prevPanel.gameObject.SetActive(false);
        prevPanel.OnClose?.Invoke();

        currPanel.gameObject.SetActive(true);
        currPanel.OnOpen?.Invoke();

        return currPanel;

    }

    //Ensures that all Panels have been Disabled
    void RemoveAllPanels()
    {
        foreach (SQ_Panel panel in switcherRoot.GetComponentsInChildren<SQ_Panel>())
        {
            panel.OnRemoved.Invoke();
        }
    }
}
