using System.Collections;
using UnityEngine;

public class BeginBattle : State
{
    public BeginBattle(BattleSystem battleSystem) : base(battleSystem)
    {
    }
    
    public override IEnumerator EnterState()
    {
        //DO UI STUFF
        
        yield return new WaitForSeconds(2f);
        
        BattleSystem.ChangeState(new PlayerTurn(BattleSystem));
    }
    
    
}
