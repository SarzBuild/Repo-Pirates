using System;
using System.Collections;
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

    private void Awake()
    {
        Player.Stats.CurrentHealth = Player.Stats.MaxHealth;
        Enemy.Stats.CurrentHealth = Enemy.Stats.MaxHealth;
    }
    
    private void Start()
    {
        Initialize(new BeginBattle(this));
    }

    private void Update()
    {
        Debug.Log(CurrentState);
    }

    public void OnButtonInteraction(int index)
    {
        if (index > Player.Stats.Abilities.Length) return;
        StartCoroutine(CurrentState.UseAbility(Player.Stats.Abilities[index]));
    }

    public IEnumerator UseAbility(AbilityBase ability, CombatantController user, CombatantController target)
    {
        Debug.Log(user.Stats.EntityName + ability.AbilityName + ability.AbilityType);
        switch (ability.AbilityType) //Checks the ability's type and calls the DoAbility Function passing to the entities functions.
        {
            case AbilityType.HEAL:
                user.Heal((int)ability.DoAbility());
                yield break;
            case AbilityType.ATTACK:
                target.Damaged((int)ability.DoAbility());
                target.PlayDamageAnimation(); //for the feedback of damage
                yield break;
            case AbilityType.STATUSEFFECT:
                target.SetStatusEffect((int)ability.DoAbility());
                target.PlayDamageAnimation(); //for the feedback of damage
                yield break;
            case AbilityType.DOUBLEEDGE:
                target.Damaged((int)(ability.DoAbility() * 1.3f));
                user.Damaged(5);
                target.PlayDamageAnimation();
                user.PlayDamageAnimation();
                yield break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void ApplyEffectOnTurnBeginning(int value, CombatantController user)
    {
        user.Damaged(value / (value*2)); //Otherwise the player gets attacked
        user.EffectLastingTimeTurns--; //And the lasting time of the effect gets updated.
    }
}
