using UnityEngine;
using System.Collections;

public class Consumable : Item
{
    public Consumable(string pName, EGenreItem pGender, EQuality pQuality, int pWeight)
        :base(pName, pGender, pQuality, pWeight)
    {
        Stackable = true;
    }
}
