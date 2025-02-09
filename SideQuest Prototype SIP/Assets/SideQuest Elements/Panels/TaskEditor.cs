using UnityEngine;

public class TaskEditor : SQ_Panel
{
    public enum EditorMode { Create, Edit };
    EditorMode mode = EditorMode.Create;
    Task task;

    private void Start()
    {
        OnOpen(mode);
    }

    public void OnOpen(EditorMode modeType)
    {
        switch (mode)
        {
            case EditorMode.Create:
                mode = EditorMode.Create;
                break;

            case EditorMode.Edit:
                mode = EditorMode.Edit;
                UpdateDetails();
                break;

            default:
                mode = EditorMode.Create;
                break;
        }
    }

    public void EditTask()
    {
        //Update Info with current details
    }

    public void OnFinished()
    {
        switch (mode)
        {
            case EditorMode.Create:
                UploadTask();
                break;
            case EditorMode.Edit:
                UpdateDetails();
                break;
            default:
                break;
        }
    }

    public void UploadTask()
    {

    }

    public void UpdateDetails() { }

    void updateUI()
    {

    }

    void GetDetails()
    {

    }
}
