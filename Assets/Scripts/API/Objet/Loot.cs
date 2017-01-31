using UnityEngine;
using System.Collections;

public class Loot
{
    public ILootable Obj;
    public float Chance;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pObj"></param>
    /// <param name="pChance">Chance en % si inf à 0 alors = 0 si sup à 100 alors = 100</param>
    public Loot(ILootable pObj, float pChance)
    {
        Obj = pObj;

        if (pChance > 100)
        {
            Chance = 100;
        }
        else if (pChance < 0)
        {
            Chance = 0;
        }
        else
        {
            Chance = pChance;
        }
    }

    /// <summary>
    /// Effectue un jet en %, si réusit, renvoi l'Item sinon renvoi null 
    /// </summary>
    /// <returns></returns>
    public Item Jet()
    {
        Item item = null;

        if (Random.Range(0,100) <= Chance)
        {
            item = Obj.JetLoot();
        }

        return item;
    }
}

