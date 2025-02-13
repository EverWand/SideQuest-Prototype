public class RootPanel : SQ_Panel
{
    TaskList taskList;
    PanelSwitcher switcher;

    private void Start()
    {
        taskList = GameManager.instance.GetComponent<TaskList>();
        switcher = GameManager.instance.GetComponent<PanelSwitcher>();
    }

    public void Handle_AddTask()
    {
        OpenEditor(TaskEditorPanel.EditorMode.Create, taskList?.AddTask());
    }

    public void Handle_RemoveTask()
    {
        taskList.RemoveTask(taskList.focusTask); //Remove the focusTask from the instance's tasklist
    }

    public void Handle_EditTask()
    {
        OpenEditor(TaskEditorPanel.EditorMode.Edit, taskList?.focusTask);
    }



    /* Condensed way to open the task editor based on edit mode and what task is being edited. */
    void OpenEditor(TaskEditorPanel.EditorMode mode, Task task)
    {
        TaskEditorPanel editor = switcher.SwitchPanel<TaskEditorPanel>() as TaskEditorPanel; //Switch to EditorPanel

        editor.OnOpen(mode, task); //Open Editor in Task Creation Mode
    }
}
