using System;
using UnityEngine;
using UnityEngine.Events;


public class Task : MonoBehaviour
{
    [System.Serializable]
    public struct TaskDetails
    {
        public string name;
        public float targetTime;
        public float currTime;
        public bool isComplete;

       public TaskDetails(string name)
       {
            this.name = name;
            this.targetTime = 0;
            this.currTime = 0;
            this.isComplete = false;
        }
    }

    [SerializeField] TaskDetails _details;

    [SerializeField] public TaskDetails taskDetails { get => _details; private set => _details = value; }

    public delegate void OnDetailUpdateCall(Task task);
    public OnDetailUpdateCall OnDetailsUpdate;


    public void SetTaskDetails(TaskDetails details)
    {
        taskDetails = details;
        OnDetailsUpdate?.Invoke(this);
    }
}

