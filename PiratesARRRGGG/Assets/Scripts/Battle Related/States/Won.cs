using System.Collections;
using UnityEngine;

public class Won : State
{
    public Won(BattleSystem battleSystem) : base(battleSystem)
    {
    }

    public override IEnumerator EnterState()
    {
        BattleSystem.UI.SetEndMessage("You won!", Color.green);
        return base.EnterState();
    }
}
