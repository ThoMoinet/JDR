using UnityEngine;
using System.Collections;

public class PatternWeaponBuilder
{
    public string Name;
    public int Weight;
    public Weapon.EGenreWeapon Gender;

    private Rand[] _charac;

    public PatternWeaponBuilder(string pName, int pWeight, Weapon.EGenreWeapon pGender)
    {
        Name = pName;
        Weight = pWeight;
        Gender = pGender;

        _charac = new Rand[Statistic.NbWeaponStatistic];

        for (int i = 0; i < Statistic.NbWeaponStatistic; i++)
        {
            _charac[i] = new Rand(0, 0);
        }
    }

    #region Set
    public Rand SetStr
    {
        set { _charac[(int)Statistic.EWeaponStat.Str] = value; }
    }
    public Rand SetInt
    {
        set { _charac[(int)Statistic.EWeaponStat.Int] = value; }
    }
    public Rand SetAgi
    {
        set { _charac[(int)Statistic.EWeaponStat.Agi] = value; }
    }
    public Rand SetCha
    {
        set { _charac[(int)Statistic.EWeaponStat.Cha] = value; }
    }
    public Rand SetCc
    {
        set { _charac[(int)Statistic.EWeaponStat.Cc] = value; }
    }
    public Rand SetCt
    {
        set { _charac[(int)Statistic.EWeaponStat.Ct] = value; }
    }
    public Rand SetSpd
    {
        set { _charac[(int)Statistic.EWeaponStat.Spd] = value; }
    }
    public Rand SetResiP
    {
        set { _charac[(int)Statistic.EWeaponStat.ResiP] = value; }
    }
    public Rand SetResiM
    {
        set { _charac[(int)Statistic.EWeaponStat.ResiM] = value; }
    }
    public Rand SetPa
    {
        set { _charac[(int)Statistic.EWeaponStat.Pa] = value; }
    }
    public Rand SetHp
    {
        set { _charac[(int)Statistic.EWeaponStat.Hp] = value; }
    }
    public Rand SetMana
    {
        set { _charac[(int)Statistic.EWeaponStat.Mana] = value; }
    }

    public Rand SetDamageMin
    {
        set { _charac[(int)Statistic.EWeaponStat.DamageMin] = value; }
    }

    public Rand SetDamageMax
    {
        set { _charac[(int)Statistic.EWeaponStat.DamageMax] = value; }
    }

    public Rand SetRange
    {
        set { _charac[(int)Statistic.EWeaponStat.Range] = value; }
    }

    #endregion

    public Rand[] GetValues
    {
        get { return _charac; }
    }
}
