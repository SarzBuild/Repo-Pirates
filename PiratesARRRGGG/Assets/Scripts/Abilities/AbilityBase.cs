using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//What the ability is;
//Attack will do minus;
//Heal will do plus;
//Status Effect will leave a lasting minus effect.
public enum AbilityType { ATTACK, HEAL, STATUSEFFECT, DOUBLEEDGE }

//Base for abilities
public abstract class AbilityBase : ScriptableObject
{
    //Inherited variables
    public string AbilityName;
    public Sprite Icon;
    public AbilityType AbilityType;

    public float Damage;
    public GameObject VFX;
    public GameObject Animation;

    //Overridable functions 
    public abstract void Initialize();
    public abstract float DoAbility();

    public void PlayAnimation()
    {
        if (Animation)
        {
            GameObject animation = Instantiate(Animation);            
            Destroy(animation, 1f);

        }
        if (VFX)
        {
            GameObject vfx = Instantiate(VFX);
            Destroy(vfx, 1f);
        }
        
    }
}
