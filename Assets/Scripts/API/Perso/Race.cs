using UnityEngine;
using System.Collections;
using System;

public class Race
{
    public string Name;

    private Rand[] _charac;

    public Race(string pNom, RandomBuilder pBuilder)
    {
        Name = pNom;

        _charac = pBuilder.GetValues;
    }

    public Race(Race pRace)
    {
        Name = pRace.Name;

        for (int i = 0; i < Statistic.NbStatistique; i++)
        {
            _charac[i] = pRace._charac[i];
        }
    }

    public void ApplicationCharac(Character pPerso)
    {
        for (int i = 0; i < Statistic.NbStatistique; i++)
        {
            pPerso.Charac[i] = new Characteristic(_charac[i].Generate(true));
        }

        pPerso.Charac[(int)Statistic.EStat.Hp] = new CharacteristicConsumable(_charac[(int)Statistic.EStat.Hp].Generate(true));
        pPerso.Charac[(int)Statistic.EStat.Mana] = new CharacteristicConsumable(_charac[(int)Statistic.EStat.Mana].Generate(true));
        pPerso.Charac[(int)Statistic.EStat.Pa] = new CharacteristicConsumable(_charac[(int)Statistic.EStat.Pa].Generate(true));
    }

    /// <summary>
    /// Retoune la liste des couts avec un cout par ligne
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        string txt = "";



        return txt;
    }

    public Rand Charac(Statistic.EStat pEStat)
    {
        return _charac[(int)pEStat];
    }
}
