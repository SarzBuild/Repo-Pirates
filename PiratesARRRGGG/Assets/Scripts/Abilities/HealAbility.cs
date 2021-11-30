using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Heal", fileName = "newHealingAbility")]
public class HealAbility : AbilityBase
{
    
    public override void Initialize()
    {
        throw new System.NotImplementedException();
    }

    public override float DoAbility()
    {
        Debug.Log("Heal");
        //PlayAnimation();
        return 100f;
    }
}
