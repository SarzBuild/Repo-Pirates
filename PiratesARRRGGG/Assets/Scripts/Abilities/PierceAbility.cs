using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Pierce", fileName = "newPierceAbility")]
public class PierceAbility : AbilityBase
{
    public override void Initialize()
    {
        throw new System.NotImplementedException();
    }

    public override float DoAbility()
    {
        Debug.Log("Ramm!");
        PlayAnimation();
        return Damage;
    }
}
