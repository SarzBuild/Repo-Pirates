using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//What the ability is;
//Attack will do minus;
//Heal will do plus;
//Status Effect will leave a lasting minus effect.
public enum AbilityType { ATTACK, HEAL, STATUSEFFECT }

//Base for abilities
public abstract class AbilityBase : ScriptableObject
{
    //Inherited variables
    public string abilityName;
    public Sprite icon;
    public AbilityType abilityType;  


    //Overridable functions 
    public abstract void Initialize();
    public abstract float DoAbility();

    public void PlayAnimation(GameObject animation, GameObject VFX)
    {
        Instantiate(animation);
        Instantiate(VFX);
    }
}
