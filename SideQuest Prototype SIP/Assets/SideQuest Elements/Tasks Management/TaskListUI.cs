using UnityEngine;

public class TaskListUI : MonoBehaviour
{
    [SerializeField] GameObject TaskPrefab;
    [SerializeField] Transform TaskListRoot;

    [SerializeField] TaskList taskList;

    public delegate void TaskClickedCall(Task task);
    public TaskClickedCall OnTaskClicked;



    private void Awake()
    {
        if (taskList == null)
        {
            taskList = GameManager.instance.GetComponent<TaskList>();
        }

        DrawTasks();
    }
    /* Draws all the saved tasks as Task Displays to the Task List Display*/
    public void DrawTasks()
    {
        ClearDisplay(); //Clear the current display
        //LOOP: go through every task that's inside of the task list
        foreach (Task task in taskList.Get_List())
        {
            CreateTask(task); //Create a task UI element based on given task
        }
    }

    void ClearDisplay()
    {
        foreach (TaskUI task in TaskListRoot.GetComponentsInChildren<TaskUI>())
        {
            Destroy(task.gameObject);
        }
    }

    void CreateTask(Task task)
    {
        if (task == null) return;

        GameObject newTask = Instantiate(TaskPrefab, Vector3.zero, Quaternion.identity, TaskListRoot);
        TaskUI taskUI = newTask.GetComponent<TaskUI>();

        taskUI.BindTask(task);
        taskUI.OnClicked += Handle_TaskClicked;

        task.SetTaskDetails(task.taskDetails);
    }

    public void Handle_TaskClicked(Task task)
    {
        OnTaskClicked.Invoke(task);
    }
}
