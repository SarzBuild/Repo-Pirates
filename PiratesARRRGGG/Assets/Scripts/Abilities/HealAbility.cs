using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Heal", fileName = "newHealingAbility")]
public class HealAbility : AbilityBase
{
    public float Heal;
    /*public GameObject VFX;
    public GameObject Animation;*/
    public override void Initialize()
    {
    }

    public override float DoAbility()
    {
        PlayAnimation();
        return Heal;
    }
}
