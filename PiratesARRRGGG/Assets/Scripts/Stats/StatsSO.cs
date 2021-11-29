using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "newStats", menuName = "Data/Stats")]
public class StatsSO : ScriptableObject
{
    //Combatant stats
    [SerializeField] public string entityName;
    [SerializeField] public int maxHealth;
    [SerializeField] public int currentHealth;
    
    //Combatant abilities list
    [SerializeField] public AbilityBase[] ablities;
    
}
