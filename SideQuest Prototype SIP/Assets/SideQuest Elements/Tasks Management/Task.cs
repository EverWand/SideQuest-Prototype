using TMPro;
using UnityEngine;

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

    public delegate void ClickedCall(Task task);
    public ClickedCall OnClicked;

    [SerializeField] TextMeshProUGUI labelTxt;

    [SerializeField] TaskDetails taskDetails;

    void OnValidate()
    {
#if UNITY_EDITOR
        FullUpdate();
#endif
    }

    public void Handle_OnClicked(){ OnClicked.Invoke(this);}

    public void SetTaskDetails(TaskDetails details)
    {
        taskDetails = details;
        FullUpdate();
    }

    void FullUpdate()
    {
        SetLabel(taskDetails.name);
    }

    void SetLabel(string labelIn)
    {
        if (labelTxt != null)
            labelTxt.text = labelIn;
    }

    public TaskDetails GetDetails()
    {
        return taskDetails;
    }
}
