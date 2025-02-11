using UnityEngine;

public class RootPanel : SQ_Panel
{
    TaskList taskList;
    PanelSwitcher switcher;

    private void Start()
    {
        taskList = GameManager.instance.GetComponent<TaskList>();
        switcher = GameManager.instance.GetComponent<PanelSwitcher>();
    }

    public void Handle_AddTask() {
        TaskEditorPanel editor = switcher.SwitchPanel<TaskEditorPanel>() as TaskEditorPanel; //Switch to EditorPanel

        editor.OnOpen(TaskEditorPanel.EditorMode.Create, taskList.AddTask(new Task())); //Open Editor in Task Creation Mode
    }
    
    public void Handle_RemoveTask() {
        taskList.RemoveFocusTask();
    }

    public void Handle_EditTask() {
        TaskEditorPanel editor = switcher.SwitchPanel<TaskEditorPanel>() as TaskEditorPanel; //Switch to EditorPanel

        editor.OnOpen(TaskEditorPanel.EditorMode.Edit, taskList.focusTask); //Open Editor in Edit Mode
    }
}
