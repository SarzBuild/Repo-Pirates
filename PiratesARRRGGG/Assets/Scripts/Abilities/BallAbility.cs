using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Ball", fileName = "newBallAbility")]
public class BallAbility : AbilityBase
{
    /*public float Damage;
    public GameObject VFX;
    public GameObject Animation;*/
    public override void Initialize()
    {
    }

    public override float DoAbility()
    {
        PlayAnimation();
        return Damage;
    }
}
