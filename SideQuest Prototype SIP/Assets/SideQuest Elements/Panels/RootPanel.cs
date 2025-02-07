using UnityEngine;

public class RootPanel : MonoBehaviour
{
    public Task.TaskDetails demoDetails;

    [SerializeField] TaskList taskList;

    public void AddTasktoList() {
        taskList.AddTask(demoDetails);
    }
}
