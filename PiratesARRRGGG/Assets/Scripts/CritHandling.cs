using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CritHandling : MonoBehaviour
{
    private int critMultiplier;
    
    public int CheckCrit(int abilityPower, int chancesModifier)
    {
        if (chancesModifier <= 0) return 0; //If chances are equals to 0, return 0
        if(chancesModifier > 100) chancesModifier = 100; //Set max chances
        
        var percentage = Random.Range(1, 101); //returns either 0 or 100
        return (chancesModifier >= percentage) switch //If chances are greater than percentage, we apply the crit
        {
            true => abilityPower + SetMultiplier(abilityPower),
            false => abilityPower
        };
    }

    private int SetMultiplier(int power)
    {
        //Just a tables returning out values depending on the abilities' strength 
        critMultiplier = power switch
        {
            var n when (n > 0 && n <= 2) => 1,
            var n when (n > 2 && n <= 4) => 2,
            var n when (n > 4 && n <= 6) => 3,
            var n when (n > 6 && n <= 8) => 4,
            var n when (n > 8 && n <= 10) => 5,
            var n when (n > 10) => 6,
            _ => critMultiplier
        };
        return critMultiplier;
    }
}
