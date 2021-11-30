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
        Initialize(new BeginBattle(this));
    }

    private void Update()
    {
        Debug.Log(CurrentState);
    }

    public void OnButtonInteraction(int index)
    {
        StartCoroutine(CurrentState.UseAbility(Player.stats.ability[index]));
    }
}
