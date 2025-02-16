using System;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class Task : MonoBehaviour
{
    [System.Serializable]
    public struct TaskDetails
    {
        public string name;
        public float elapsedTime;  // Time the task has been active (in seconds)
        public float targetTime;   // Target time for completion (in seconds)
        public bool isComplete;

        public TaskDetails(string name, int hours, int minutes, float currElapsedTime)
        {
            this.name = name;
            this.elapsedTime = currElapsedTime;  // Starts at 0 and counts up when active
            this.targetTime = (hours * 3600) + (minutes * 60);  // Convert to seconds
            this.isComplete = false;
        }
    }

    [SerializeField] TaskDetails details;
    public TaskDetails taskDetails { get => details; private set => details = value; }

    private Thread timerThread;
    private bool isPaused = false;
    private bool stopThread = false;

    public event Action<Task> OnDetailsUpdate;
    public UnityAction OnTimerTick;

    private void Awake()
    {

    }

    public void SetTaskDetails(string taskName, int targetHours, int targetMinutes, float currElapsedTime)
    {
        taskDetails = new TaskDetails(taskName, targetHours, targetMinutes, currElapsedTime);
        OnDetailsUpdate?.Invoke(this);
    }

    public void SetTaskDetails(TaskDetails detailSet)
    {
        taskDetails = detailSet;
        OnDetailsUpdate?.Invoke(this);
    }

    //=====| TIMER TRACKER |=====
    public void StartTimer()
    {
        if (timerThread != null && timerThread.IsAlive)
        {
            stopThread = true;
            timerThread.Join();
        }

        isPaused = false;
        stopThread = false;
        timerThread = new Thread(TickTimer);
        timerThread.Start();
    }

    public void PauseTimer()
    {
        isPaused = true;
    }

    public void ResumeTimer()
    {
        isPaused = false;
    }

    public void StopTimer()
    {
        if (timerThread != null && timerThread.IsAlive)
        {
            stopThread = true;
            timerThread.Join();
        }
    }

    private void TickTimer()
    {
        while (!details.isComplete && !stopThread)
        {
            if (!isPaused)
            {
                details.elapsedTime += 1f;
            }


            Thread.Sleep(1000);
        }
    }

    //====| DETAIL GETTERS |=====
    public int GetTimeDifference()
    {
        return Mathf.FloorToInt(Mathf.Abs(details.targetTime - details.elapsedTime));
    }

    public (int hours, int minutes) GetTimeFormatted(float baseTime)
    {
        int totalSeconds = Mathf.FloorToInt(baseTime);
        return (totalSeconds / 3600, (totalSeconds % 3600) / 60);
    }
}
