using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginBattle : State
{
    public BeginBattle(BattleSystem battleSystem) : base(battleSystem)
    {
    }
    
    public override IEnumerator EnterState()
    {
        
        
        yield return new WaitForSeconds(0.1f);
        
        BattleSystem.ChangeState(new PlayerTurn(BattleSystem));
    }
    
    
}
