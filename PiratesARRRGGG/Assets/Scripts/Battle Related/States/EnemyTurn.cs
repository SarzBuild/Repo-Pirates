using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyTurn : State
{
    public EnemyTurn(BattleSystem battleSystem) : base(battleSystem)
    {
        throw new System.NotImplementedException();
    }

    public override IEnumerator EnterState()
    {
        return base.EnterState();

        if (true)
        {
            BattleSystem.ChangeState(new Lost(BattleSystem));
        }
        else
        {
            BattleSystem.ChangeState(new PlayerTurn(BattleSystem));
        }
    }
}
