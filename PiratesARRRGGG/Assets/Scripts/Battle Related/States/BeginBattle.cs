using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginBattle : State
{
    public BeginBattle(BattleSystem battleSystem, CombatantController player, CombatantController enemy) : base(battleSystem,player,enemy)
    {
    }
    
    public override IEnumerator EnterState()
    {
        //DO UI STUFF
        
        yield return new WaitForSeconds(2f);
        
        BattleSystem.ChangeState(new PlayerTurn(BattleSystem, Player, Enemy));
    }
    
    
}
