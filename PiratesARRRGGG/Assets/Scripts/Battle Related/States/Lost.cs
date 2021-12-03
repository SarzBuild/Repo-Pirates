using System.Collections;
using UnityEngine;

public class Lost : State
{
    public Lost(BattleSystem battleSystem) : base(battleSystem)
    {
    }

    public override IEnumerator EnterState()
    {
        BattleSystem.UI.SetEndMessage("You lost!", Color.red);
        return base.EnterState();
    }
}
