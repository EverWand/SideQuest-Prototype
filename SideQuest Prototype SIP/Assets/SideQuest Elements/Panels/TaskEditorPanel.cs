using System;
using TMPro;
using UnityEngine;
using static Task;

public class TaskEditorPanel : SQ_Panel
{
    public enum EditorMode { Create, Edit };
    EditorMode mode = EditorMode.Create;
    Task.TaskDetails editorDetails;

    Task task;

    //Label
    [SerializeField] TMP_InputField nameInput;
    //Time
    [SerializeField] TMP_InputField hours;
    [SerializeField] TMP_InputField minutes;
    //Date
    [SerializeField] TMP_InputField year;
    [SerializeField] TMP_InputField month;
    [SerializeField] TMP_InputField day;

    public void SetupEditor(EditorMode modeType, Task editTask)
    {
        if (editTask == null) { GameManager.instance.GetComponent<PanelSwitcher>()?.GoBack(); return; }
        mode = modeType;
        task = editTask;
        editorDetails = task.taskDetails;

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
        //DEBUG : Task or Details null
        if (task == null)
        {
            Debug.LogError("Task or task details are null in WriteTaskDetails!");
            return;
        }

        /*Setting Display Information*/
        //___Label___
        nameInput.text = editorDetails.name;
        //___Hours
        hours.text = task.GetTimeFormatted(editorDetails.targetTime).hours.ToString();
        //__Minutes
        minutes.text = task.GetTimeFormatted(editorDetails.targetTime).minutes.ToString();
    }
    //Reads the Input Values to construct task detail structure
    TaskDetails ReadInputDetails()
    {
        //Name
        editorDetails.name = nameInput.text;
        //Parse the Time Text input to set the task's target time value
        editorDetails.targetTime = TimeToSeconds(Int32.Parse(hours.text), Int32.Parse(minutes.text));


        return editorDetails;
    }

    float TimeToSeconds(int hrs, int mins)
    {
        return ((hrs * 60) + mins) * 60;
    }
}
