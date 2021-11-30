using UnityEngine;

public class BattleSystem : StateMachine
{
    //Variables
    [SerializeField] private CombatantController player;
    [SerializeField] private CombatantController enemy;
    [SerializeField] private GUI ui;

    //Public accessors for the states.
    public CombatantController Player => player;
    public CombatantController Enemy => enemy;
    public GUI UI => ui;

    private void Start()
    {
        Player.stats.currentHealth = Player.stats.maxHealth;
        //Enemy.stats.currentHealth = Enemy.stats.maxHealth;
        Initialize(new BeginBattle(this));
    }

    private void Update()
    {
        Debug.Log(CurrentState);

        Debug.Log(Player.stats.currentHealth);
    }

    public void OnButtonInteraction(int index)
    {
        if (index > Player.stats.ability.Length) return;
        StartCoroutine(CurrentState.UseAbility(Player.stats.ability[index]));
    }
}
