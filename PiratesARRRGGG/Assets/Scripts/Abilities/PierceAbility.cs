using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Pierce", fileName = "newPierceAbility")]
public class PierceAbility : AbilityBase
{
    public override void Initialize()
    {
    }

    public override float DoAbility()
    {
        PlayAnimation();
        return Damage;
    }
}
