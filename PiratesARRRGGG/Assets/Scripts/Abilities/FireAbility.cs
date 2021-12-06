using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Fire", fileName = "newFireAbility")]
public class FireAbility : AbilityBase
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
