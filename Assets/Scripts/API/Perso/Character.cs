using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Character
{
    public string Name;
    public EGenre Genre;
    public int Age;
    public int Lvl;
    public decimal Argent;
    public int PtsAmelioration;

    public Race Species;
    public Job Classe;

    public CharacteristicConsumable Xp;

    public List<Item> Inventaire;
    public List<Competence> Competences;
    public List<Character> Familiers;

    public string ImageEmplacement;

    private Characteristic[] _charac;
    private int _ptsAmeliorationLvl;

    public enum EGenre
    {
        Homme, Femme, Autre
    }


    public Character()
    {

    }

    public Character(string pNom, EGenre pGenre, int pAge, Race pEspece, Job pClasse, string pImageEmplacement)
    {
        Name = pNom;
        Genre = pGenre;
        Age = pAge;
        Lvl = 1;
        Argent = 0;

        _charac = new Characteristic[Statistic.NbStatistique];

        _ptsAmeliorationLvl = 5;
        PtsAmelioration = _ptsAmeliorationLvl;

        Species = pEspece;
        Classe = pClasse;

        Xp = new CharacteristicConsumable(100 + Formule(Lvl));
        Xp.ValeurActu = 0;

        Inventaire = new List<Item>();
        Competences = new List<Competence>();
        Familiers = new List<Character>();

        ImageEmplacement = pImageEmplacement;

        Species.ApplicationCharac(this);
    }

    public Character(Character pChar)
    {
        Name = pChar.Name;
        Genre = pChar.Genre;
        Age = pChar.Age;
        Lvl = pChar.Lvl;
        Argent = pChar.Argent;
        PtsAmelioration = pChar.PtsAmelioration;

        Species = pChar.Species;
        Classe = pChar.Classe;

        Xp = pChar.Xp;

        Inventaire = pChar.Inventaire;
        Competences = pChar.Competences;
        Familiers = pChar.Familiers;

        ImageEmplacement = pChar.ImageEmplacement;

        for (int i = 0; i < Statistic.NbStatistique; i++)
        {
            _charac[i] = pChar._charac[i];
        }
    }

    #region GetSet
    public Characteristic[] Charac
    {
        get { return _charac; }
        set { _charac = value; }
    }
    #endregion

    /// <summary>
    /// Ajoute l'xp donné au personnage et gère le lvl up
    /// </summary>
    /// <param name="qte"></param>
    public void AddXp(float xpCount)
    {
        float xpRestant = Xp.Valeur - Xp.ValeurActu;

        if (xpCount > xpRestant) //Si on a gagné plus d'xp que nécessaire
        {
            xpRestant = xpCount - xpRestant;
            LvlUp();
            Xp.ValeurActu = xpRestant;
        }
        else if (xpCount == xpRestant) //Si on a gagné juste ce qu'il falait
        {
            LvlUp();
        }
        else
        {
            Xp.ValeurActu += xpCount;
        }
    }

    /// <summary>
    /// Gestion de passage au niveau sup
    /// </summary>
    private void LvlUp()
    {
        Lvl += 1;
        Xp.Valeur += Formule(Lvl);
        Xp.ValeurActu = 0;
        PtsAmelioration += _ptsAmeliorationLvl;
    }

    /// <summary>
    /// Commande de MJ permetant de faire passer un personnage au lvl 'LvlNum'
    /// Il faut que le lvl demandé soit > au niveau actuel
    /// </summary>
    public void MjPassageAtLvl(int LvlNum)
    {
        if (LvlNum > Lvl)
        {
            int dif = LvlNum - Lvl;

            for (int i = 0; i < dif; i++)
            {
                LvlUp();
            }
        }
    }

    /// <summary>
    /// Commande de MJ permetant de faire passer un personnage à 'LvlupCount' niveau sup
    /// </summary>
    public void MjLvlUp(int LvlupCount)
    {
        for (int i = 0; i < LvlupCount; i++)
        {
            LvlUp();
        }
    }

    /// <summary>
    /// Stock la formule de calcule de l'xp
    /// </summary>
    /// <param name="pLvl"></param>
    /// <returns></returns>
    private float Formule(int pLvl)
    {
        return Mathf.Round(pLvl * Mathf.Exp(3));
    }

    /// <summary>
    /// Augemente une caractéristique avec le prix fixé dans la classe du personnage et retourne True si réusit ou False si pas possible
    /// </summary>
    /// <param name="pEStat">Caractéristique à augmenter d'un cran</param>
    /// <returns></returns>
    public bool UpCarac(Statistic.EStat pEStat)
    {
        bool ok = false;

        // On commence par regarder si le joueur posséde au moins un Pts d'amélioration
        if (PtsAmelioration >= 1)
        {
            if (Classe.Charac(pEStat) < 0) // Si le prix est négatif, ça ne coute que 1 pts au joueur pour augmenter de X sa Carac
            {
                //Debug.Log(pEcarac + " : " + CaracWithEnum(pEcarac).Valeur + " - > " + (CaracWithEnum(pEcarac).Valeur + Mathf.Abs(Classe.CaracWithEnum(pEcarac))));

                PtsAmelioration -= 1;
                Charac[(int)pEStat].ValueChange(Charac[(int)pEStat].Valeur + Mathf.Abs(Classe.Charac(pEStat)));
                ok = true;
            }
            else if(Classe.Charac(pEStat) > 0) // Si le prix est possitif, le joueur dépensera X pour augmenter sa carac de 1 pts
            {
                if (Classe.Charac(pEStat) <= PtsAmelioration)
                {
                    //Debug.Log(pEcarac + " : " + CaracWithEnum(pEcarac).Valeur + " - > " + (CaracWithEnum(pEcarac).Valeur + 1));

                    PtsAmelioration -= Classe.Charac(pEStat);
                    Charac[(int)pEStat].ValueChange(Charac[(int)pEStat].Valeur + 1);
                    ok = true;
                }
            }
        }
        return ok;
    }
}
