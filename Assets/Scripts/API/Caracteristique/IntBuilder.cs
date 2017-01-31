using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntBuilder
{
    protected int[] _charac;

    /// <summary>
    /// Instancie le builder et met par défaut toutes les valeurs à 0
    /// </summary>
    public IntBuilder()
    {
        _charac = new int[Statistic.NbStatistique];

        for (int i = 0; i < Statistic.NbStatistique; i++)
        {
            _charac[i] = 0;
        }
    }

    #region Set
    public int SetStr
    {
        set { _charac[(int)Statistic.EStat.Str] = value; }
    }
    public int SetInt
    {
        set { _charac[(int)Statistic.EStat.Int] = value; }
    }
    public int SetAgi
    {
        set { _charac[(int)Statistic.EStat.Agi] = value; }
    }
    public int SetCha
    {
        set { _charac[(int)Statistic.EStat.Cha] = value; }
    }
    public int SetCc
    {
        set { _charac[(int)Statistic.EStat.Cc] = value; }
    }
    public int SetCt
    {
        set { _charac[(int)Statistic.EStat.Ct] = value; }
    }
    public int SetSpd
    {
        set { _charac[(int)Statistic.EStat.Spd] = value; }
    }
    public int SetResiP
    {
        set { _charac[(int)Statistic.EStat.ResiP] = value; }
    }
    public int SetResiM
    {
        set { _charac[(int)Statistic.EStat.ResiM] = value; }
    }
    public int SetPa
    {
        set { _charac[(int)Statistic.EStat.Pa] = value; }
    }
    public int SetHp
    {
        set { _charac[(int)Statistic.EStat.Hp] = value; }
    }
    public int SetMana
    {
        set { _charac[(int)Statistic.EStat.Mana] = value; }
    }

    #endregion

    public int[] GetValues
    {
        get { return _charac; }
    }

}
