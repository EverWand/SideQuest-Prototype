using System.Collections.Generic;
using UnityEngine;



public class TaskManager : MonoBehaviour
{
    List<Task> tasks = new List<Task>(); // List of Taks within the Manager

    void AddTask(Task newTask) { 
        tasks.Add(newTask);
    }


}

