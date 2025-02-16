using CustomUtil;
using TMPro;
using UnityEngine;

public class DebugAttack : MonoBehaviour
{
    [SerializeField] TMP_InputField hoursTxt;
    [SerializeField] TMP_InputField minTxt;

    public float Get_InputTime()
    {
        float debugTime = TimeConverter.TimeToSeconds(int.Parse(hoursTxt.text), int.Parse(minTxt.text));
        Debug.Log(debugTime);
        //Returns the input time in seconds
        return debugTime;
    }
}
