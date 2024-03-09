using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statTOChange = new StatToChange();
    public int amountToChangeStat;
    public AttributesToChange attributesTOChange = new AttributesToChange();
    public int amountToChangeAttribute;
    


    public void UseItem()
    {
        if(statTOChange == StatToChange.health)
        {
            //Health consume
        }
    }

    public enum StatToChange
    {
        Damage,
        None,
        health,
        mana,
        stamina
    };

    public enum AttributesToChange
    {
        none,
        Strenth,
        defence,
        Intellegince,
        agility,
        
    };


}
