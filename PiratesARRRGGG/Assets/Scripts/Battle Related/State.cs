using System.Collections;

public abstract class State
{
    public BattleSystem BattleSystem;

    protected State(BattleSystem battleSystem)
    {
        BattleSystem = battleSystem;
    }

    public virtual IEnumerator EnterState()
    {
        yield break;
    }

    public virtual IEnumerator UseAbility(AbilityBase ability)
    {
        yield break;
    }
    
    
}
