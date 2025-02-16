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

    public void DrawTasks()
    {
        //Debug.Log("Drawing " + (GameManager.instance.GetComponent<TaskList>().Get_List().Length) + " Tasks");
        
        ClearDisplay();

        foreach(Task task in taskList.Get_List())
        {
            CreateTask(task);
        }
    }

    void ClearDisplay() {
        foreach (TaskUI task in TaskListRoot.GetComponentsInChildren<TaskUI>()) {
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
