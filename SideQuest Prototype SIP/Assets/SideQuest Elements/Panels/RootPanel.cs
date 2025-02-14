using TMPro;
using UnityEngine;

public class RootPanel : SQ_Panel
{
    TaskList taskList;
    PanelSwitcher switcher;

    [SerializeField] TaskListUI taskListUI;
    [SerializeField] TextMeshProUGUI SelectedTaskLabel;

    private void Start()
    {
        taskList = GameManager.instance.GetComponent<TaskList>();
        switcher = GameManager.instance.GetComponent<PanelSwitcher>();

        taskListUI.OnTaskClicked += UpdateSelectedTaskDisplay;
    }

    protected override void Handle_OnOpen()
    {
        taskListUI.DrawTasks();
    }

    public void AddTask_Pressed()
    {
        OpenEditor(TaskEditorPanel.EditorMode.Create, taskList.AddTask());
    }

    public void RemoveTask_Pressed()
    {
        taskList.RemoveTask(taskList.focusTask); //Remove the focusTask from the instance's tasklist
    }

    public void OpenEditor_Pressed()
    {
        OpenEditor(TaskEditorPanel.EditorMode.Edit, taskList?.focusTask);
    }

    /* Condensed way to open the task editor based on edit mode and what task is being edited. */
    void OpenEditor(TaskEditorPanel.EditorMode mode, Task task)
    {
        TaskEditorPanel editor = switcher.SwitchPanel<TaskEditorPanel>() as TaskEditorPanel; //Switch to EditorPanel

        editor.SetupEditor(mode, task); //Open Editor in Task Creation Mode
    }

    void UpdateSelectedTaskDisplay(Task task)
    {
        taskList.Set_Focus(task);
        
        SelectedTaskLabel.text = task.taskDetails.name;
        
        taskList.focusTask.OnDetailsUpdate += UpdateSelectedTaskDisplay;
    }
}
