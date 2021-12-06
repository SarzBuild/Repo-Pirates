using UnityEngine;

public class CombatantController : MonoBehaviour
{
    //Access to Combatant stats
    [SerializeField] public StatsSO Stats;
    [SerializeField] public CritHandling CritHandling;
    public GUI UI => GUI.Instance;
    [SerializeField] public bool AffectedByEffect = false;
    [SerializeField] public int EffectLastingTimeTurns;
    
    public bool CheckIfAlive() => Stats.currentHealth >= 0;

    private void HealthModifier(int value) //The actual function 
    {
        Stats.currentHealth += value;
        if(value < 0) UI.SpawnFloatingDamage(transform, value.ToString(), Color.red);
        if(value > 0) UI.SpawnFloatingDamage(transform, value.ToString(), Color.green);
        if(value == 0) UI.SpawnFloatingDamage(transform,"Missed!", Color.white);

        if (Stats.currentHealth >= Stats.maxHealth) Stats.currentHealth = Stats.maxHealth;
        if (Stats.currentHealth <= 0) Stats.currentHealth = 0;
    }
    
    public void Damaged(int value)
    {
        HealthModifier(-value + -CritHandling.CheckCrit(value, Stats.physicalPower) + -Stats.physicalPower);
    }

    public void Heal(int value)
    {
        HealthModifier(value + CritHandling.CheckCrit(value, Stats.magicPower) + Stats.magicPower);
    }

    public void SetStatusEffect(int magicPower)
    {
        AffectedByEffect = true;
        EffectLastingTimeTurns = magicPower;
    }
}
