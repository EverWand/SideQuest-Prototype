using TMPro;
using UnityEngine;
using static Task;

public class TaskUI : MonoBehaviour
{
    public Task task;

    [SerializeField] TextMeshProUGUI labelTxt;

    public delegate void ClickedCall(Task task);
    public ClickedCall OnClicked;


    void OnValidate()
    {
#if UNITY_EDITOR
        FullUpdate();
#endif
    }


    public void Handle_OnClicked() {     
        OnClicked.Invoke(task); 
    }



    void FullUpdate()
    {
        SetLabel(task.taskDetails.name);
    }

    void SetLabel(string labelIn)
    {
        if (labelTxt != null)
            labelTxt.text = labelIn;
    }
}
