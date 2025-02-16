using UnityEngine.UI;
using TMPro;
using UnityEngine;
using CustomUtil;

public class TaskUI : MonoBehaviour
{
    public Task task { get; private set; }

    /*=====| ELEMENT REFERENCES |=====*/
    [SerializeField] TextMeshProUGUI labelTxt;      //Label
    [SerializeField] TextMeshProUGUI EstTimeTxt;    //Target Time 
    [SerializeField] TextMeshProUGUI CurrTimeTxt;   //Current Time

    /*=====| EVENTS |=====*/
    //___CLICKED
    public delegate void ClickedCall(Task task);
    public ClickedCall OnClicked;


    void OnValidate()
    {
        /*Only Call this segment if inside the editor*/
        #if UNITY_EDITOR
            //GAURD: Task doesn't exist
            if (task == null) { return; }
            FullDisplayUpdate(task); //Update to the current task's details
        #endif
    }

    /*=====| Interface |=====*/
    /*Handling CLICKED event*/
    public void Handle_OnClicked()
    {
        OnClicked.Invoke(task);
    }
    /*Binds a Task to the Task Display*/
    public void BindTask(Task newTask)
    {
        //Remove the Update Calls for the previously bound task
        if (task != null) { 
            task.OnDetailsUpdate -= FullDisplayUpdate; 
            task.OnMinuteReached -= UpdateCurrentTimeDisplay;
        }

        task = newTask; //Link to the new task
        
        task.OnDetailsUpdate += FullDisplayUpdate; //Subscribe to the detail update to also update the UI
        task.OnMinuteReached += UpdateCurrentTimeDisplay;
    }


    /*Updates each Element to the task details from binded task*/
    void FullDisplayUpdate(Task updatedTask)
    {
        if (task == null) return;

        //Update Label
        SetLabel(task.taskDetails.name);
        //Update Current Time Display
        SetTimeDisplay(CurrTimeTxt, TimeConverter.GetTimeFormatted(task.taskDetails.elapsedTime));
        //Update Target Time Display
        SetTimeDisplay(EstTimeTxt, TimeConverter.GetTimeFormatted(task.taskDetails.targetTime));
    }


    /*=====| TASK DETAILS TO DISPLAY |=====*/
    /*____Label */
    void SetLabel(string labelIn)
    {
        if (labelTxt != null)
            labelTxt.text = labelIn;
    }

    /*____Time Display*/
    void SetTimeDisplay(TextMeshProUGUI txtDisplay, (int hr, int min) Time) {
        string timePrint = Time.hr + "hrs " + Time.min +"mins ";

        txtDisplay.text = timePrint;
    }

    void UpdateCurrentTimeDisplay() {
        SetTimeDisplay(CurrTimeTxt, TimeConverter.GetTimeFormatted(task.taskDetails.elapsedTime));
    }
}
