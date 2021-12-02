using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Ball", fileName = "newBallAbility")]
public class BallAbility : AbilityBase
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
        Debug.Log("Cannon attack!");
        PlayAnimation();
        return Damage;
    }
}
