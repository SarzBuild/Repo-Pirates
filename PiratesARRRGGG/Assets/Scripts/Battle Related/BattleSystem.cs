using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : StateMachine
{
    //Variables
    [SerializeField] private CombatantController player;
    [SerializeField] private CombatantController enemy;

    //Public accessors for the states.
    public CombatantController Player => player;
    public CombatantController Enemy => enemy;
    public GUI UI => GUI.Instance;

    private void Start()
    {
        Player.Stats.currentHealth = Player.Stats.maxHealth;
        Enemy.Stats.currentHealth = Enemy.Stats.maxHealth;
        Initialize(new BeginBattle(this));
    }

    private void Update()
    {
        Debug.Log(CurrentState);
    }

    public void OnButtonInteraction(int index)
    {
        if (index > Player.Stats.ability.Length) return;
        StartCoroutine(CurrentState.UseAbility(Player.Stats.ability[index]));
    }

    public IEnumerator UseAbility(AbilityBase ability, CombatantController user, CombatantController target)
    {
        Debug.Log(user.Stats.entityName + ability.abilityName + ability.abilityType);
        switch (ability.abilityType) //Checks the ability's type and calls the DoAbility Function passing to the entities functions.
        {
            case AbilityType.HEAL:
                user.Heal((int)ability.DoAbility());
                yield break;
            case AbilityType.ATTACK:
                target.Damaged((int)ability.DoAbility());
                //target.PlayDamageAnimation(); //for the feedback of damage
                yield break;
            case AbilityType.STATUSEFFECT:
                target.SetStatusEffect((int)ability.DoAbility());
                yield break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void ApplyEffectOnTurnBeginning(int value, CombatantController user)
    {
        user.Damaged(value / value*2); //Otherwise the player gets attacked
        user.EffectLastingTimeTurns--; //And the lasting time of the effect gets updated.
    }
}
