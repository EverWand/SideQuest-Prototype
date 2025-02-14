using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TaskUI : MonoBehaviour
{
    public Task task { get; private set; }

    [SerializeField] TextMeshProUGUI labelTxt;

    public delegate void ClickedCall(Task task);
    public ClickedCall OnClicked;

    public UnityAction DisplayInfoUpdated;


    void OnValidate()
    {
#if UNITY_EDITOR
        FullUpdate();
#endif
    }

    private void Start()
    {
        DisplayInfoUpdated += FullUpdate;
        OnClicked += SetColor;
    }

    public void Handle_OnClicked()
    {
        OnClicked.Invoke(task);
    }



    void FullUpdate()
    {
        if (task == null) return;

        SetLabel(task.taskDetails.name);
        SetColor(task);
    }

    void SetColor(Task task)
    {

    }
    void SetLabel(string labelIn)
    {
        if (labelTxt != null)
            labelTxt.text = labelIn;
    }

    public void BindTask(Task InTask)
    {
        task = InTask;
        FullUpdate();
    }
}
