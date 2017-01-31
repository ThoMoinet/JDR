using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBuilder
{
    protected Rand[] _charac;

    /// <summary>
    /// Instancie le builder et met par défaut toutes les valeurs à 0
    /// </summary>
    public RandomBuilder()
    {
        _charac = new Rand[Statistic.NbStatistique];

        for (int i = 0; i < Statistic.NbStatistique; i++)
        {
            _charac[i] = new Rand(0, 0);
        }
    }

    #region Set
    public Rand SetStr
    {
        set { _charac[(int)Statistic.EStat.Str] = value; }
    }
    public Rand SetInt
    {
        set { _charac[(int)Statistic.EStat.Int] = value; }
    }
    public Rand SetAgi
    {
        set { _charac[(int)Statistic.EStat.Agi] = value; }
    }
    public Rand SetCha
    {
        set { _charac[(int)Statistic.EStat.Cha] = value; }
    }
    public Rand SetCc
    {
        set { _charac[(int)Statistic.EStat.Cc] = value; }
    }
    public Rand SetCt
    {
        set { _charac[(int)Statistic.EStat.Ct] = value; }
    }
    public Rand SetSpd
    {
        set { _charac[(int)Statistic.EStat.Spd] = value; }
    }
    public Rand SetResiP
    {
        set { _charac[(int)Statistic.EStat.ResiP] = value; }
    }
    public Rand SetResiM
    {
        set { _charac[(int)Statistic.EStat.ResiM] = value; }
    }
    public Rand SetPa
    {
        set { _charac[(int)Statistic.EStat.Pa] = value; }
    }
    public Rand SetHp
    {
        set { _charac[(int)Statistic.EStat.Hp] = value; }
    }
    public Rand SetMana
    {
        set { _charac[(int)Statistic.EStat.Mana] = value; }
    }

    #endregion

    public Rand[] GetValues
    {
        get { return _charac; }
    }

}
