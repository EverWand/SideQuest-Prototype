using UnityEngine;
using UnityEngine.UIElements;

public class Task : MonoBehaviour
{
    public string taskName = "";
    public int deadlineDays = -1;
    public Time estimatedCompletion = new Time();
    public bool isComplete = false;
    public Color color;

}
