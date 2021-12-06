using System;
using System.Collections;
using UnityEngine;

public class PlayerTurn : State
{
    private bool _useOnce;
    public PlayerTurn(BattleSystem battleSystem) : base(battleSystem)
    {
    }

    public override IEnumerator EnterState()
    {
        _useOnce = false;
        BattleSystem.UI.SetText("Choose an ability!");
        
        if (!BattleSystem.Player.AffectedByEffect) return base.EnterState(); //If the player is not affected by a status effect, we just yield return from base.
        
        BattleSystem.ApplyEffectOnTurnBeginning(BattleSystem.Enemy.Stats.MagicPower, BattleSystem.Player);
        return base.EnterState();
    }
    
    public override IEnumerator UseAbility(AbilityBase ability)
    {
        if (_useOnce) yield break;
        _useOnce = true;
        BattleSystem.StartCoroutine(BattleSystem.UseAbility(ability, BattleSystem.Player, BattleSystem.Enemy));

        BattleSystem.UI.SetText(BattleSystem.Player.Stats.EntityName + " uses " + ability.AbilityName + "!");

        yield return new WaitForSeconds(2f); // We could change it until the animation of the ability is complete instead of a fixed time amount.
        
        if (!BattleSystem.Enemy.CheckIfAlive()) //If the enemy is not alive anymore, player won.
        {
            BattleSystem.ChangeState(new Won(BattleSystem));
        }
        else // Otherwise, we pass along the turn to the enemy.
        {
            BattleSystem.ChangeState(new EnemyTurn(BattleSystem));
        }
    }
}
