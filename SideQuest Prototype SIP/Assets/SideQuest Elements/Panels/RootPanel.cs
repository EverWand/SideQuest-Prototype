using UnityEngine;

public class RootPanel : SQ_Panel
{
    [SerializeField] TaskList taskList;

    public void Handle_AddTask() {
         TaskEditor editor = GameManager.instance.GetComponent<PanelSwitcher>().SwitchPanel<TaskEditor>() as TaskEditor; //Switch to EditorPanel

        editor.OnOpen(TaskEditor.EditorMode.Create); //Open Editor in Task Creation Mode
    }

    public void Handle_RemoveTask() { }

    public void Handle_EditTask() {
        TaskEditor editor = GameManager.instance.GetComponent<PanelSwitcher>().SwitchPanel<TaskEditor>() as TaskEditor; //Switch to EditorPanel

        editor.OnOpen(TaskEditor.EditorMode.Edit); //Open Editor in Edit Mode
    }
}
