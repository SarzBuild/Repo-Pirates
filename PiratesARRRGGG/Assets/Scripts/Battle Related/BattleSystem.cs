using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : StateMachine
{
    //Variables
    [SerializeField] private CombatantController player;
    [SerializeField] private CombatantController enemy;
    [SerializeField] private string ui;
    
    //Public accessors for the states.
    public CombatantController Player => player;
    public CombatantController Enemy => enemy;
    public string UI => ui;

    //When the game starts, initialize the state machine with the begin battle state.
    private void Start()
    {
        Initialize(new BeginBattle(this));
    }

    
}
