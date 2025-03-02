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


    /* EVENT HANDLERS */
    /* When the panel is opened, draw the tasks */
    protected override void Handle_OnOpen()
    {
        taskListUI.DrawTasks();
    }

    /* When the Add Button is pressed, Open the Editor Panel in Creation Mode */
    public void AddTask_Pressed()
    {
        Task task = taskList.AddTask();

        Debug.Log(task);

        OpenEditor(TaskEditorPanel.EditorMode.Create, task);
    }
    /* When the Remove Button is pressed, Remove the Selected task */
    public void RemoveTask_Pressed()
    {
        taskList.RemoveTask(taskList.focusTask); //Remove the focusTask from the instance's tasklist
    }
    /* When the Edit Button is pressed, Open the Editor Panel in Edit Mode */
    public void OpenEditor_Pressed()
    {
        OpenEditor(TaskEditorPanel.EditorMode.Edit, taskList?.focusTask);
    }
    /* When The Start button is pressed, begin the Selected Task's Timer*/
    public void StartTask_Pressed()
    {
        taskList.focusTask?.StartTimer();
    }

    /* Condensed way to open the task editor based on edit mode and what task is being edited. */
    void OpenEditor(TaskEditorPanel.EditorMode mode, Task task)
    {
        TaskEditorPanel editor = switcher?.SwitchPanel<TaskEditorPanel>() as TaskEditorPanel; //Switch to EditorPanel

        editor.SetupEditor(mode, task); //Open Editor in Task Creation Mode
    }

    /* Updates the Selected Task Display */
    void UpdateSelectedTaskDisplay(Task task)
    {
        taskList.Set_Focus(task);   // Set the focus task to the selected task

        SelectedTaskLabel.text = taskList.focusTask?.taskDetails.name; //Update the Selected Task Label
        taskList.focusTask.OnDetailsUpdate += UpdateSelectedTaskDisplay; //Subscribe to the task's details update event
    }
}
