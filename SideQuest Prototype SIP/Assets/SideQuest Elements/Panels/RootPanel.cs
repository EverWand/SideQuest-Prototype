using UnityEngine;
using static Task;

public class RootPanel : SQ_Panel
{
    public Task.TaskDetails demoDetails;

    [SerializeField] TaskList taskList;

    public void AddTasktoList() {
        //Debug.Log("Adding new Task to List - Talking to " + taskList.name);
        taskList.AddTask(demoDetails);
    }
}
