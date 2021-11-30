using System;
using System.Collections;
using UnityEngine;

public class PlayerTurn : State
{
    public PlayerTurn(BattleSystem battleSystem) : base(battleSystem)
    {
    }

    public override IEnumerator EnterState()
    {
        
        //DO UI STUFF PLAYER TURN
        
        if (!BattleSystem.Player.affectedByEffect) return base.EnterState(); //If the player is not affected by a status effect, we just yield return from base.
        
        BattleSystem.Player.Damaged(BattleSystem.Enemy.stats.magicPower); //Otherwise the player gets attacked
        BattleSystem.Player.effectLastingTime--; //And the lasting time of the effect gets updated.
        return base.EnterState();
    }
    
    public override IEnumerator UseAbility(AbilityBase ability)
    {
        //DO UI STUFF PLAYER USES ABILITY
        Debug.Log("HELLOOOOO");
        switch (ability.abilityType) //Checks the ability's type and calls the DoAbility Function passing to the entities functions.
        {
            case AbilityType.HEAL:
                BattleSystem.Player.Heal((int)ability.DoAbility());
                break;
            case AbilityType.ATTACK:
                BattleSystem.Enemy.Damaged((int)ability.DoAbility());
                break;
            case AbilityType.STATUSEFFECT:
                BattleSystem.Enemy.SetStatusEffect((int)ability.DoAbility());
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

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
