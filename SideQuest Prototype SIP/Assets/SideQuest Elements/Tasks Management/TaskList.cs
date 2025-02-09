using System.Collections.Generic;
using UnityEngine;
using static Task;

public class TaskList : MonoBehaviour , ISaveSystem
{
    [SerializeField] List<Task> tasks = new List<Task>();

    [SerializeField] public Task focusTask { get; private set; } //The List's selected task

    public delegate Task TaskAddCall(Task task);
    public TaskAddCall OnTaskAdded;


    public void AddTask(Task task)
    {
        tasks.Add(task);
        OnTaskAdded.Invoke(task);
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
}
