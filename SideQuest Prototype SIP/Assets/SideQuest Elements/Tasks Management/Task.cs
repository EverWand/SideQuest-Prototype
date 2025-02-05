using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Task : MonoBehaviour
{
    public string taskLabel = "";
    public int deadline = -1;
    public float estimatedCompletion;
    public bool isComplete = false;
    public Color color;

    [SerializeField] TextMeshProUGUI labelTxt;
    [SerializeField] TextMeshProUGUI date;
    [SerializeField] TextMeshProUGUI time;
    [SerializeField] TextMeshProUGUI estTime;

    [SerializeField] UnityEngine.UI.Image checkImage;

    private void OnValidate()
    {
        #if UNITY_EDITOR
            FullUpdate();
        #endif

    }

    void FullUpdate() { 
        SetLabel(taskLabel);            //Update label
        setDate(deadline.ToString());   //Update Date
        SetTime(time.ToString());       //Update Time
        SetEstTime(estTime.ToString()); //Update Estimated Time
        setCompleteDisplay();           //Check Box
    }
    void SetLabel(string labelIn) { 
        labelTxt.text = labelIn;
    }
    void SetEstTime(string labelIn)
    {
        estTime.text = labelIn;
    }
    void SetTime(string labelIn)
    {
        time.text = labelIn;
    }

    void setDate(string labelIn) { 
        date.text = labelIn;
    }
    void setCompleteDisplay() { 
        checkImage.enabled = isComplete;
    }
}
