using System.Collections;

public class Lost : State
{
    public Lost(BattleSystem battleSystem) : base(battleSystem)
    {
    }

    public override IEnumerator EnterState()
    {
        //DO UI STUFF
        return base.EnterState();
    }
}
