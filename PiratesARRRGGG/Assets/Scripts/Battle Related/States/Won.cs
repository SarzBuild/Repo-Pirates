using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Won : State
{
    public Won(BattleSystem battleSystem, CombatantController player, CombatantController enemy) : base(battleSystem,player,enemy)
    {
    }

    public override IEnumerator EnterState()
    {
        //DO UI STUFF
        return base.EnterState();
    }
}
