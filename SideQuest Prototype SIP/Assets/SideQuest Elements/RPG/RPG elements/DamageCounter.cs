using TMPro;
using UnityEngine;

public class DamageCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI damageTxt;

    public void updateDisplay(float damage) {
        damageTxt.text = damage.ToString();
    }
}
