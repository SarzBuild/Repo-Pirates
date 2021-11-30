using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class State
{
    public BattleSystem BattleSystem;
    
    protected State(BattleSystem battleSystem)
    {
        BattleSystem = battleSystem;
    }
    
    
    public virtual IEnumerator EnterState()
    {
        yield break;
    }

    public virtual IEnumerator UseAbility(AbilityBase ability, CombatantController self, CombatantController target)
    {
        yield break;
    }
    
    
}
