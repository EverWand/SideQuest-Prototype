using UnityEngine;
using static Task;

public class TaskListUI : MonoBehaviour
{
    [SerializeField] GameObject TaskPrefab;
    [SerializeField] Transform TaskListRoot;

    [SerializeField] TaskList taskList;




    private void Awake()
    {
        taskList = GameManager.instance.GetComponent<TaskList>();

        taskList.OnTaskAdded += CreateTask;
    }

    Task CreateTask(Task task)
    {
        GameObject newTask = Instantiate(TaskPrefab, Vector3.zero, Quaternion.identity, TaskListRoot);
        //Debug.Log("Created Task");
        TaskUI taskUI = newTask.GetComponent<TaskUI>();
        taskUI.task = task;

        return taskUI.task;
    }
}
