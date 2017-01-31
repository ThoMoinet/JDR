using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Permet de déterminer les couts en pts de chaques stats pour permettre une spécialisation
/// Un cout positif = Joueur qui dépence x pts pour + 1 dans la stat
/// Un cout null = Pas d'amélioration possible
/// Un cout negatif = Joueur qui dépence 1 pts pour + x dans la stat
/// </summary>
public class Job
{
    public string Name;

    private int[] _charac;

    /// <summary>
    /// Constructeur pour créer une Classe à partir de 0
    /// </summary>
    public Job(string pNom, IntBuilder pBuilder)
    {
        Name = pNom;

        _charac = pBuilder.GetValues;
    }

    /// <summary>
    /// Constructeur pour construire un classe à partir d'une autre (clone)
    /// </summary>
    /// <param name="pClasse"></param>
    public Job(Job pJob)
    {
        Name = pJob.Name;

        for (int i = 0; i < Statistic.NbStatistique; i++)
        {
            _charac[i] = pJob._charac[i];
        }
    }


    /// <summary>
    /// Retoune la liste des couts avec un cout par ligne
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        string txt;

        txt = CoutString("Force", _charac[(int)Statistic.EStat.Str]) + Environment.NewLine;
        txt += CoutString("Intelligence", _charac[(int)Statistic.EStat.Int]) + Environment.NewLine;
        txt += CoutString("Agilité", _charac[(int)Statistic.EStat.Agi]) + Environment.NewLine;
        txt += CoutString("Charisme", _charac[(int)Statistic.EStat.Cha]) + Environment.NewLine;
        txt += CoutString("Cap de Combat", _charac[(int)Statistic.EStat.Cc]) + Environment.NewLine;
        txt += CoutString("Cap de Tir", _charac[(int)Statistic.EStat.Ct]) + Environment.NewLine;
        txt += CoutString("Vitesse", _charac[(int)Statistic.EStat.Spd]) + Environment.NewLine;
        txt += CoutString("Resist Physique", _charac[(int)Statistic.EStat.ResiP]) + Environment.NewLine;
        txt += CoutString("Resist Magique", _charac[(int)Statistic.EStat.ResiM]) + Environment.NewLine;
        txt += CoutString("Santé", _charac[(int)Statistic.EStat.Hp]) + Environment.NewLine;
        txt += CoutString("Mana", _charac[(int)Statistic.EStat.Mana]) + Environment.NewLine;
        txt += CoutString("Pa", _charac[(int)Statistic.EStat.Pa]);

        return txt;
    }

    public string CoutString(string NameCarac, int CoutCarac)
    {
        string txt = "";

        if (CoutCarac < 0) //Si négatif
        {
            txt = NameCarac + " : 1 pts = + " + Mathf.Abs(CoutCarac); 
        }
        else if (CoutCarac == 0) //Si null
        {
            txt = NameCarac + " pas de up possible";
        }
        else //Si positif
        {
            txt = NameCarac + " : " + Mathf.Abs(CoutCarac) + " pts = + 1";
        }

        return txt;
    }

    public int Charac(Statistic.EStat pEStat)
    {
        return _charac[(int)pEStat];
    }
}
