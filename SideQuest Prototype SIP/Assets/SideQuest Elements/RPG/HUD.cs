using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] HealthBar hpBar;
    [SerializeField] DebugAttack debugAttack;
    [SerializeField] HealthSystem hp;
    [SerializeField] DamageCounter dmgCounter;


    private void Start()
    {
        hp = GetComponent<HealthSystem>();
    
          hp.OnDeath += Handle_Death;
    }

    public void Handle_Attack() {
        //GUARD: No task is Selected yet 
        if (GameManager.instance.GetComponent<TaskList>().focusTask == null) { return; }


        float damage = GameManager.instance.GetComponent<TaskList>().focusTask.Get_Reward(debugAttack.Get_InputTime());
        //Deal Damage to the Health System Reference
        hp.TakeDamage(damage);

        //Update the Damage Counter
        dmgCounter.updateDisplay(damage);
    }

    void Handle_Death() { 
        hp.ResetHP();
    }
}
