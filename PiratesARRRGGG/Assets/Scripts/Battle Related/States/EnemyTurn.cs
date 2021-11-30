using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyTurn : State
{
    public EnemyTurn(BattleSystem battleSystem, CombatantController player, CombatantController enemy) : base(battleSystem,player,enemy)
    {
    }

    public override IEnumerator EnterState()
    {
        
        
        return base.EnterState();

        /*if (true)
        {
            BattleSystem.ChangeState(new Lost(BattleSystem));
        }
        else
        {
            BattleSystem.ChangeState(new PlayerTurn(BattleSystem));
        }*/
    }
}
