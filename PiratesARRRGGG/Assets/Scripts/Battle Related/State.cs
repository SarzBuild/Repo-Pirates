using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class State
{
    public BattleSystem BattleSystem;
    public CombatantController Player;
    public CombatantController Enemy;
    
    protected State(BattleSystem battleSystem, CombatantController player, CombatantController enemy)
    {
        BattleSystem = battleSystem;
        Player = player;
        Enemy = enemy;
    }

    public virtual IEnumerator EnterState()
    {
        yield break;
    }

    public virtual IEnumerator UseAbility(AbilityBase ability)
    {
        yield break;
    }
    
    
}
