using UnityEngine;

[CreateAssetMenu(fileName = "newStats", menuName = "Data/Stats")]
public class StatsSO : ScriptableObject
{
    //Combatant stats
    [SerializeField] public string entityName;
    [SerializeField] public int maxHealth;
    [SerializeField] public int currentHealth;
    [SerializeField] public int physicalPower;
    [SerializeField] public int magicPower;
    
    //Combatant abilities list
    [SerializeField] public AbilityBase[] ability;
    

}
