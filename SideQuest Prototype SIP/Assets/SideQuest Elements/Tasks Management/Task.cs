using CustomUtil;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
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

    Coroutine timerRoutine;
    bool isPaused = false;

    public event Action<Task> OnDetailsUpdate;
    public UnityAction OnTimerTick;
    public UnityAction OnMinuteReached;


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
        timerRoutine = StartCoroutine(TickTimer());
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
        StopCoroutine(timerRoutine);
    }

    IEnumerator TickTimer()
    {
        while (!details.isComplete)
        {
            if (!isPaused)
            {
                details.elapsedTime += 1f;
                if (details.elapsedTime % 60 == 0)
                {
                    OnMinuteReached?.Invoke();
                }

                yield return new WaitForSeconds(1);
            }
        }
    }

    //====| DETAIL GETTERS |=====

    /*Calculates Full Reward of the Task*/
    public float Get_Reward(float seconds)
    {

        (float hr, float min) = TimeConverter.GetTimeFormatted(taskDetails.targetTime);
        //Base Reward by the length of the Task
        float reward = (hr + (min / 60));
        print($"Base Reward: {reward}");
        //Create a modifier for how close the time difference is to the target time
        // Lambda Expression for calculating the modifier of the reward
        Func<float> mod = () =>
        {
            //Get the difference between the target time and the current time
            float timeDifference = TimeConverter.GetTimeDifference(seconds, taskDetails.targetTime);

            Debug.Log($"Time Difference: {timeDifference}");

            //Return the modifier based on the difference
            return Mathf.Clamp01(1 - (timeDifference / taskDetails.targetTime));
        };

        //BASE * MOD = Reward
        reward = reward * (1 + mod());
        Debug.Log($"Reward: {reward}");
        return reward; //Return the Reward
    }

    public string GetJsonPrint()
    {
        return JsonUtility.ToJson(taskDetails,true);
    }   
}
