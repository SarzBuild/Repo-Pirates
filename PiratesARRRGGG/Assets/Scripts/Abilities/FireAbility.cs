using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Fire", fileName = "newFireAbility")]
public class FireAbility : AbilityBase
{
    /*public float Damage;
    public GameObject VFX;
    public GameObject Animation;*/
        public override void Initialize()
    {
        throw new System.NotImplementedException();
    }

    public override float DoAbility()
    {
        Debug.Log("Fire attack!");
        PlayAnimation();
        return Damage;
    }
    
    
    
}
