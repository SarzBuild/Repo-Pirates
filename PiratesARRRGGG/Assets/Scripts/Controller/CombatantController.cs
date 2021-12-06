using UnityEngine;
using DG.Tweening;

public class CombatantController : MonoBehaviour
{
    //Access to Combatant stats
    [SerializeField] public StatsSO Stats;
    [SerializeField] public CritHandling CritHandling;
    public GUI UI => GUI.Instance;
    [SerializeField] public bool AffectedByEffect = false;
    [SerializeField] public int EffectLastingTimeTurns;
    
    public bool CheckIfAlive() => Stats.CurrentHealth > 0;

    private void HealthModifier(int value) //The actual function 
    {
        Stats.CurrentHealth += value;
        if(value < 0) UI.SpawnFloatingDamage(transform, value.ToString(), Color.red);
        if(value > 0) UI.SpawnFloatingDamage(transform, value.ToString(), Color.green);
        if(value == 0) UI.SpawnFloatingDamage(transform,"Missed!", Color.white);

        if (Stats.CurrentHealth >= Stats.MaxHealth) Stats.CurrentHealth = Stats.MaxHealth;
        if (Stats.CurrentHealth <= 0) Stats.CurrentHealth = 0;
    }
    
    public void Damaged(int value)
    {
        HealthModifier(-value + -CritHandling.CheckCrit(value, Stats.PhysicalPower) + -Stats.PhysicalPower);
    }

    public void Heal(int value)
    {
        HealthModifier(value + CritHandling.CheckCrit(value, Stats.MagicPower) + Stats.MagicPower);
    }

    public void SetStatusEffect(int magicPower)
    {
        AffectedByEffect = true;
        EffectLastingTimeTurns = magicPower;
    }
    public void PlayDamageAnimation()
    {
        transform.DOShakePosition(0.8f, 3f, 20, 30f, false, false).SetDelay(0.75f);
    }
}
