using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected BattleSystem BattleSystem;
    
    protected State(BattleSystem battleSystem)
    {
    }
    
    
    public virtual IEnumerator EnterState()
    {
        yield break;
    }

    public virtual IEnumerator ExitState()
    {
        yield break;
    }

    public virtual IEnumerator UseAbility()
    {
        yield break;
    }
    
    
}
