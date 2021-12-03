using System.Collections;
using UnityEngine;

public class EnemyTurn : State
{
    private int _healCounter = 3;
    private int _statusEffectCounter = 1;

    public EnemyTurn(BattleSystem battleSystem) : base(battleSystem)
    {
    }

    public override IEnumerator EnterState()
    {
        if (BattleSystem.Enemy.AffectedByEffect) BattleSystem.ApplyEffectOnTurnBeginning(BattleSystem.Player.Stats.magicPower, BattleSystem.Enemy);

        BattleSystem.UI.SetText(BattleSystem.Enemy.Stats.entityName + " fights back!");
        
        yield return new WaitForSeconds(2f);
        if (BattleSystem.Enemy.Stats.currentHealth < 40 && _healCounter <= 1)
        {
            BattleSystem.StartCoroutine(BattleSystem.UseAbility(BattleSystem.Enemy.Stats.ability[0], BattleSystem.Enemy, BattleSystem.Player));
            SendText(BattleSystem.Enemy.Stats.ability[0]);
            _healCounter--;
        }
        else if (BattleSystem.Enemy.Stats.currentHealth < 120 && _statusEffectCounter <= 1)
        {
            BattleSystem.StartCoroutine(BattleSystem.UseAbility(BattleSystem.Enemy.Stats.ability[1], BattleSystem.Enemy, BattleSystem.Player));
            SendText(BattleSystem.Enemy.Stats.ability[1]);
            _statusEffectCounter--;
        }
        else
        {
            var random = Random.Range(0, 2);
            switch (random)
            {
                case 0:
                    BattleSystem.StartCoroutine(BattleSystem.UseAbility(BattleSystem.Enemy.Stats.ability[2], BattleSystem.Enemy, BattleSystem.Player));
                    SendText(BattleSystem.Enemy.Stats.ability[2]);
                    break;
                case 1:
                    BattleSystem.StartCoroutine(BattleSystem.UseAbility(BattleSystem.Enemy.Stats.ability[3], BattleSystem.Enemy, BattleSystem.Player));
                    SendText(BattleSystem.Enemy.Stats.ability[3]);
                    break;
            }
        }
        
        yield return new WaitForSeconds(2.5f);


        if (!BattleSystem.Player.CheckIfAlive())
        {
            BattleSystem.ChangeState(new Lost(BattleSystem));
        }
        else
        {
            BattleSystem.ChangeState(new PlayerTurn(BattleSystem));
        }
    }

    private void SendText(AbilityBase ability) => BattleSystem.UI.SetText(BattleSystem.Enemy.Stats.entityName + " uses " + ability.abilityName + "!");
}
