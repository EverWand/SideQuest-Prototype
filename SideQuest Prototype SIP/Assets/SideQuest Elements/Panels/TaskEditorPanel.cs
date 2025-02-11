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

    public void OnFinished()
    {
        task.SetTaskDetails(ReadInputDetails());

        GameManager.instance.GetComponent<PanelSwitcher>().GoBack(); //Go back to previous Screen
    }

    void WriteTaskDetails()
    {
        //Name
        nameInput.text = task.taskDetails.name;
    }

    Task.TaskDetails ReadInputDetails()
    {
        //Name
        editorDetails.name = nameInput.text;


        return editorDetails;
    }
}
