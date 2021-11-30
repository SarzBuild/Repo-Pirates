using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatantController : MonoBehaviour
{
    //Access to Combatant stats
    public StatsSO stats;
    public CritHandling CritHandling;
    public bool affectedByEffect = false;
    public int effectLastingTime;
    
    public bool CheckIfAlive() => stats.currentHealth <= 0;

    private void HealthModifier(int value)
    {
        stats.currentHealth += value;
        if (stats.currentHealth >= stats.maxHealth) stats.currentHealth = stats.maxHealth;
    }
    
    public void Damaged(int value)
    {
        HealthModifier(-value + CritHandling.CheckCrit(value, stats.physicalPower));
    }

    public void Heal(int value)
    {
        HealthModifier(value + CritHandling.CheckCrit(value, stats.magicPower));
    }

    public void SetStatusEffect(int magicpower)
    {
        affectedByEffect = true;
        effectLastingTime = magicpower;
    }
    
    
    
    
}
