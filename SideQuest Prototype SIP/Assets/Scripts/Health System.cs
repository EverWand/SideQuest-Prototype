using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    float maxHealth;
    float currHealth;
        
    public delegate void HealthChangeCall();
    public delegate void DamagedCall();
    public delegate void HealedCall();
    public delegate void DeathCall();

    public HealthChangeCall OnHealthChange;
    public DamagedCall OnDamaged;
    public HealedCall OnHealed;
    public DeathCall OnDeath;

    public float get_healthValue() { return currHealth; }

    public void TakeDamage(float damageAmount) { 
        currHealth = Mathf.Clamp((currHealth-damageAmount), 0, maxHealth);
        OnDamaged.Invoke();
        OnHealthChange.Invoke();
        
        if (currHealth <= 0) { OnDeath.Invoke(); }
        
    }
    public void GainHealth(float amount) {
        if (currHealth == maxHealth) { return; }

        currHealth = Mathf.Clamp((currHealth + amount), 0, maxHealth);
        OnHealed.Invoke();
        OnHealthChange.Invoke();
    }

    public float GetPercent() { return Mathf.Clamp01(currHealth/maxHealth); }
}
