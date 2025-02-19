using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CustomUtil;

public class TaskList : MonoBehaviour, ISaveData
{
    [SerializeField] Task _focus;
    public Task focusTask { get => _focus; private set => _focus = value; } //The List's selected task


    [SerializeField] List<Task> tasks = new List<Task>();

    public delegate Task TaskAddCall(Task task);
    public TaskAddCall OnTaskAdded;
    public UnityAction OnTaskRemoved;
    public UnityAction OnTasksUpdated;


    public Task AddTask(Task task)
    {
        if (task == null) { Debug.LogError("Can not Add Null Task Value"); return null; }

        tasks.Add(task);
        OnTaskAdded?.Invoke(task);
        OnTasksUpdated?.Invoke();

        return task;
    }
    public Task AddTask()
    {
        GameObject taskObj = Instantiate(new GameObject("Task"), GameManager.instance.GetComponent<TaskList>().transform);
        Task task;
        if (taskObj != null) {
            task = taskObj.AddComponent<Task>();
        } else { task = null; }

        task.SetTaskDetails("New Task", 0, 0, 0f);

        return AddTask(task);
    }

    public void RemoveTask(Task task)
    {
        //Gaurd: Prevent Process if there's no focus to target
        if (task == null) { return; }

        if (task == focusTask) { focusTask = null; }        //Empty Focus if it's being removed
        if (tasks.Contains(task)) { tasks.Remove(task); }   //Remove the task from the list
        if (task.gameObject) { Destroy(task.gameObject); }  //Destroy game object if it exists

        OnTaskRemoved?.Invoke();
        OnTasksUpdated?.Invoke();
    }

    public void Set_Focus(Task selected)
    { focusTask = selected; }

    public Task[] Get_List() { 
        return tasks.ToArray();
    }

    /*=====| SAVE DATA |=====*/
    public void Save(ref AppData data)
    {
        data.taskList = this.tasks;

    }
    public void Load(AppData data)
    {
        this.tasks = data.taskList;
    }

}
