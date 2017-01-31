using UnityEngine;
using System.Collections;

public class Item : ILootable{

    public string Name;
    public EGenreItem Gender;
    public EQuality Quality;
    public int Weight;
    public bool Stackable; 

    public Item (string pName, EGenreItem pGender, EQuality pQuality, int pWeight)
    {
        Name = pName;
        Gender = pGender;
        Quality = pQuality;
        Weight = pWeight;
        Stackable = false;
    }

    public Item(string pName, EQuality pQuality, int pWeight)
    {
        Name = pName;
        Quality = pQuality;
        Weight = pWeight;
    }

    public Item(Item pItem)
    {
        Name = pItem.Name;
        Gender = pItem.Gender;
        Quality = pItem.Quality;
        Weight = pItem.Weight;
    }

    public enum EGenreItem
    {
        Standard, Consumable
    }

    public enum EQuality
    {
        Normal = 1, Anormal, Rare, Epique, Legendaire
    }

    public virtual Item JetLoot()
    {
        return this;
    }

    public static int GenerationQuality()
    {
        int quality = 1;
        bool flag = false;

        if (Random.Range(0F, 100F) <= 0.5F) // 0.5 % de chance de légendaire
        {
            quality = (int)Item.EQuality.Legendaire;
            flag = true;
        }

        if (!flag)
        {
            if (Random.Range(0F, 100F) <= 1) // 1 % de chance de légendaire
            {
                quality = (int)Item.EQuality.Epique;
                flag = true;
            }

            if (!flag)
            {
                if (Random.Range(0F, 100F) <= 2) // 2 % de chance de légendaire
                {
                    quality = (int)Item.EQuality.Rare;
                    flag = true;
                }

                if (!flag)
                {
                    if (Random.Range(0F, 100F) <= 5) // 5 % de chance de légendaire
                    {
                        quality = (int)Item.EQuality.Anormal;
                    }
                }
            }
        }

        return quality;
    }
}
