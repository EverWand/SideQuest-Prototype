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

    [SerializeField] public TaskDetails taskDetails { get; private set; }

    UnityAction OnDetailsUpdate; 


    public void SetTaskDetails(TaskDetails details)
    {
        taskDetails = details;
        OnDetailsUpdate.Invoke();
    }
}
