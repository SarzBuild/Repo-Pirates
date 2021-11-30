using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerTurn : State
{
    public PlayerTurn(BattleSystem battleSystem) : base(battleSystem)
    {
    }

    public override IEnumerator EnterState()
    {
        return base.EnterState();
    }
    
    public override IEnumerator UseAbility(AbilityBase ability, CombatantController self, CombatantController target)
    {
        ability.DoAbility();

        switch (ability.abilityType)
        {
            case AbilityType.HEAL:
                if (self.stats.currentHealth >= self.stats.maxHealth) self.stats.currentHealth = self.stats.maxHealth;
                else self.stats.currentHealth += (int)ability.DoAbility();
                break;
            case AbilityType.ATTACK:
                
                break;
            case AbilityType.STATUSEFFECT:
               
                break;
        }
        
        
        /*if (true)   
        {
            BattleSystem.ChangeState(new Won(BattleSystem));
        }
        else
        {
            BattleSystem.ChangeState(new EnemyTurn(BattleSystem));
        }*/
        yield break;
    }
    
}
