using UnityEngine;

[CreateAssetMenu(fileName = "newStats", menuName = "Data/Stats")]
public class StatsSO : ScriptableObject
{
    //Combatant stats
    [SerializeField] public string EntityName;
    [SerializeField] public int MaxHealth;
    [SerializeField] public int CurrentHealth;
    [SerializeField] public int PhysicalPower;
    [SerializeField] public int MagicPower;
    
    //Combatant abilities list
    [SerializeField] public AbilityBase[] Abilities;
    

}
