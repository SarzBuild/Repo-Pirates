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
    
    public override IEnumerator UseAbility()
    {
        return base.UseAbility();

        if (true)
        {
            BattleSystem.ChangeState(new Won(BattleSystem));
        }
        else
        {
            BattleSystem.ChangeState(new EnemyTurn(BattleSystem));
        }
        
    }

    public override IEnumerator ExitState()
    {
        return base.ExitState();
    }
}
