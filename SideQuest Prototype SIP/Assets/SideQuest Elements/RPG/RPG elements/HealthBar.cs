using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image fill;
    [SerializeField] HealthSystem hpSystem;

    private void Awake()
    {
        hpSystem.OnHealthChange += setPercent;
    }

    void setPercent()
    {
        fill.fillAmount = hpSystem.GetPercent();
    }

}
