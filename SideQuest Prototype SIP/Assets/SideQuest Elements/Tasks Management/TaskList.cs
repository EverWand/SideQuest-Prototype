using System.Collections.Generic;
using UnityEngine;
using static Task;

public class TaskList : MonoBehaviour
{
    [SerializeField] GameObject TaskPrefab;
    [SerializeField] Transform TaskListRoot;

    [SerializeField] List<Task> tasks = new List<Task>();

    [SerializeField] public Task focusTask { get; private set; } //The List's selected task

    public void AddTask(Task.TaskDetails details)
    {
        tasks.Add(CreateTask(details));

        Debug.Log("Current Amount of Tasks - " + tasks[tasks.Count - 1].name);
    }

    public void RemoveFocusTask()
    {
        //Gaurd: Prevent Process if there's no focus to target
        if (focusTask == null) { return; }


        //Check to see if the Focus task is the tasklist
        if (tasks.Contains(focusTask))
        {
            tasks.Remove(focusTask); //Remove the task from the list
        }

        //Destroy the Task Display if there's one
        if (focusTask.gameObject) { Destroy(focusTask.gameObject); }

        focusTask = null; // Ensures the focus task has been dereferenced after removal 
    }

    public void OnTaskSelected(Task selected)
    { focusTask = selected; }

    Task CreateTask(TaskDetails details)
    {
        GameObject newTask = Instantiate(TaskPrefab, Vector3.zero, Quaternion.identity, TaskListRoot);
        //Debug.Log("Created Task");
        Task taskScript = newTask.GetComponent<Task>();

        taskScript.SetTaskDetails(details); //Set the Details of the task
        taskScript.OnClicked += OnTaskSelected;

        return taskScript;
    }
}
