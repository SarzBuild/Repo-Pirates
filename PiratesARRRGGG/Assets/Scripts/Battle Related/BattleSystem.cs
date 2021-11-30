using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : StateMachine
{
    //Variables
    [SerializeField] private CombatantController player;
    [SerializeField] private CombatantController enemy;
    [SerializeField] private GUI ui;

    //States
    /*public BeginBattle BeginBattle { get; private set; }
    public PlayerTurn PlayerTurn { get; private set; }
    public EnemyTurn EnemyTurn { get; private set; }
    public Won Won { get; private set; }
    public Lost Lost { get; private set; }*/


    //Public accessors for the states.
    public CombatantController Player => player;
    public CombatantController Enemy => enemy;
    public GUI UI => ui;

    //When the game starts, initialize the state machine with the begin battle state.
    /*private void Awake()
    {
        BeginBattle = new BeginBattle(this);
        PlayerTurn = new PlayerTurn(this);
        EnemyTurn = new EnemyTurn(this);
        Won = new Won(this);
        Lost = new Lost(this);
    }*/
    
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
        StartCoroutine(CurrentState.UseAbility(Player.stats.ability[index], Player, Enemy));
    }
}
