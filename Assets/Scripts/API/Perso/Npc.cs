using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Npc : Character
{

    

    public Npc(string pNom, EGenre pGenre, int pAge, Race pEspece, Job pClasse, string pImageEmplacement, int pLvl) 
        :base(pNom, pGenre, pAge, pEspece, pClasse, pImageEmplacement)
    {
        if (pLvl > 1)
        {
            MjPassageAtLvl(pLvl);
            RepartitionDesPts();
        }
    }

    public Npc(Npc pNpc)
        :base(pNpc){}

    /// <summary>
    /// Permet de répartir les pts de façon automatique
    /// A améliorer avec Ia plus tard, pour l'instant Rnd
    /// </summary>
    private void RepartitionDesPts()
    {
        if (PtsAmelioration > 0)
        {
            while (PtsAmelioration > 0)
            {
                Statistic.EStat e = (Statistic.EStat)Random.Range(0, 11 + 1); // +1 Car un Range avec des int exclu le dernier Namebre

                UpCarac(e);
            }
        }
    }

    public float XpDrop()
    {
        return Mathf.Round(Random.Range(1, Xp.Valeur / 2));
    }
}
