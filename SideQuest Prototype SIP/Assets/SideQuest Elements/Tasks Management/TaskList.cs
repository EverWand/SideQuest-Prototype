using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TaskList : MonoBehaviour, ISaveSystem
{
    [SerializeField] List<Task> tasks = new List<Task>();

    [SerializeField] public Task focusTask { get; private set; } //The List's selected task

    public delegate Task TaskAddCall(Task task);
    public TaskAddCall OnTaskAdded;


    public Task AddTask(Task task)
    {
        tasks.Add(task);
        OnTaskAdded?.Invoke(task);

        return task;
    }


    public Task AddTask()
    {
        GameObject taskObj = Instantiate(new GameObject("Task"), GameManager.instance.GetComponent<TaskList>()?.transform);
        Task task = taskObj?.AddComponent<Task>();

        return AddTask(task);
    }

    public void RemoveTask(Task task)
    {
        //Gaurd: Prevent Process if there's no focus to target
        if (task == null) { return; }

        if (task == focusTask) { focusTask = null; }        //Empty Focus if it's being removed
        if (tasks.Contains(task)) { tasks.Remove(task); }   //Remove the task from the list
        if (task.gameObject) { Destroy(task.gameObject); }  //Destroy game object if it exists
    }

    public void OnTaskSelected(Task selected)
    { focusTask = selected; }

}
