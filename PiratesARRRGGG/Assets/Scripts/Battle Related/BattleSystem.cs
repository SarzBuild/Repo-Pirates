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

        Debug.Log(Player.Stats.currentHealth);
    }

    public void OnButtonInteraction(int index)
    {
        if (index > Player.Stats.ability.Length) return;
        StartCoroutine(CurrentState.UseAbility(Player.Stats.ability[index]));
    }
}
