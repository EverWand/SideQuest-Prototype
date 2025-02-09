using System.Collections.Generic;
using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    [SerializeField] Transform switcherRoot;
    [SerializeField] SQ_Panel rootPanel;
    public SQ_Panel currPanel { get; private set; } //Tracks the current Panel the Switcher is on
    public SQ_Panel prevPanel { get; private set; } //Tracks what the was the previous Panel focused on by the Switcher

    [SerializeField] List<SQ_Panel> panelList = new List<SQ_Panel>();

    private void Start()
    {
        if (rootPanel == null)
        {
            rootPanel = panelList[0]; //Make the Root the beginning panel of the list
        }

        //RemoveAllPanels(); //Disable All Panels
        FocusRootPanel();   //Make the Root panel the initial focus
    }

    /*Generic Method That will switch to a specific type of Panel if it exists*/
    public SQ_Panel SwitchPanel<T>() where T : SQ_Panel
    {
        //Go through Each Panel
        foreach (SQ_Panel panel in panelList)
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
        if (panelList.Count - 1 > index || index < 0)
        {
            Debug.LogError("Index Out of Range of " + gameObject.name + " Panel List.");
            return;
        }

        SwitchPanel(panelList[index]);
    }

    SQ_Panel SwitchPanel(SQ_Panel panel)
    {
        //test this concept out first... but maybe only disable the new prev panel and remove the old prev panel?


        /*Disable the Previous Panel*/
        prevPanel = currPanel; //Set the current panel as the previoud panel
        prevPanel.OnRemoved.Invoke();

        //Create the New Panel
        currPanel = CreatePanel(panel.panelPrefab);

        return currPanel;
    }
    public void FocusRootPanel()
    {
        if ( rootPanel == null)
        {
            rootPanel = CreatePanel(rootPanel.panelPrefab);
        }

        SwitchPanel(rootPanel);
    }

    SQ_Panel CreatePanel(GameObject panelObj)
    {
        SQ_Panel newPanel = Instantiate(panelObj, Vector3.zero, Quaternion.identity, switcherRoot).GetComponent<SQ_Panel>();
        currPanel.OnCreated.Invoke();

        return newPanel;
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
