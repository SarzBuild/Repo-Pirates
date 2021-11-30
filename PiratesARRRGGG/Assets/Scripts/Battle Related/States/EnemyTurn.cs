using System.Collections;

public class EnemyTurn : State
{
    public EnemyTurn(BattleSystem battleSystem) : base(battleSystem)
    {
    }

    public override IEnumerator EnterState()
    {
        
        
        return base.EnterState();

        /*if (true)
        {
            BattleSystem.ChangeState(new Lost(BattleSystem));
        }
        else
        {
            BattleSystem.ChangeState(new PlayerTurn(BattleSystem));
        }*/
    }
}
