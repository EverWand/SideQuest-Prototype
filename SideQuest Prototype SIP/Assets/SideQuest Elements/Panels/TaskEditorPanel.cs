using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskEditorPanel : SQ_Panel
{
    public enum EditorMode { Create, Edit };
    EditorMode mode = EditorMode.Create;
    Task.TaskDetails editorDetails;

    Task task;

    //Label
    [SerializeField] TMP_InputField nameInput;
    //Time
    [SerializeField] InputField hours;
    [SerializeField] InputField minutes;
    //Date
    [SerializeField] InputField year;
    [SerializeField] InputField month;
    [SerializeField] InputField day;

    public void OnOpen(EditorMode modeType, Task editTask)
    {
        mode = modeType;
        task = editTask;

        WriteTaskDetails();
    }


    public void Handle_OnBack()
    {
        switch (mode)
        {
            case EditorMode.Create:
                GameManager.instance.GetComponent<TaskList>()?.RemoveTask(task);
                break;
            case EditorMode.Edit:

                break;
            default:
                break;
        }

        GameManager.instance.GetComponent<PanelSwitcher>()?.GoBack();
    }
    public void Handle_OnDone()
    {
        mode = EditorMode.Edit; /*Simple fix for the Onback call trying to delete task when in creation mode... just temporarily swap it to edit to make the edits to the new task*/
        task.SetTaskDetails(ReadInputDetails()); //Set the Task's details based on the input values

        GameManager.instance.GetComponent<PanelSwitcher>()?.GoBack(); //Go back to previous Screen
    }

    /*Writes the Task Details to the UI*/
    void WriteTaskDetails()
    {
        //Name
        nameInput.text = task.taskDetails.name;
    }
    //Reads the Input Values to construct task detail structure
    Task.TaskDetails ReadInputDetails()
    {
        //Name
        editorDetails.name = nameInput.text;


        return editorDetails;
    }
}
