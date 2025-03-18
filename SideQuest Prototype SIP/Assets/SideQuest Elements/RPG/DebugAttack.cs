using CustomUtil;
using TMPro;
using UnityEngine;

public class DebugAttack : MonoBehaviour
{
    [SerializeField] TMP_InputField hoursTxt;
    [SerializeField] TMP_InputField minTxt;

    public float Get_InputTime()
    {
        int hr = hoursTxt.text == string.Empty ? 0 : int.Parse(hoursTxt.text);
        int min = minTxt.text == string.Empty ? 0 : int.Parse(minTxt.text);

        float debugTime = TimeConverter.TimeToSeconds(hr, min);
        Debug.Log(debugTime);
        //Returns the input time in seconds
        return debugTime;
    }
}
