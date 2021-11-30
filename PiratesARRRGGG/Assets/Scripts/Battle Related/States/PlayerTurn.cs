using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerTurn : State
{
    public PlayerTurn(BattleSystem battleSystem, CombatantController player, CombatantController enemy) : base(battleSystem,player,enemy)
    {
    }

    public override IEnumerator EnterState()
    {
        //DO UI STUFF PLAYER TURN
        
        if (!Player.affectedByEffect) return base.EnterState();
        
        Player.Damaged(Enemy.stats.magicPower);
        Player.effectLastingTime--;
        return base.EnterState();
    }
    
    public override IEnumerator UseAbility(AbilityBase ability)
    {
        //DO UI STUFF PLAYER USES ABILITY
        Debug.Log("HELLOOOOO");
        switch (ability.abilityType)
        {
            case AbilityType.HEAL:
                Player.Heal((int)ability.DoAbility());
                break;
            case AbilityType.ATTACK:
                Enemy.Damaged((int)ability.DoAbility());
                break;
            case AbilityType.STATUSEFFECT:
                Enemy.SetStatusEffect((int)ability.DoAbility());
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        yield return new WaitForSeconds(2f);
        
        if (Player.CheckIfAlive())   
        {
            BattleSystem.ChangeState(new Won(BattleSystem, Player, Enemy));
        }
        else
        {
            BattleSystem.ChangeState(new EnemyTurn(BattleSystem, Player, Enemy));
        }
    }
    
}
