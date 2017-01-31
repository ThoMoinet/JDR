using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Statistic
{
    public enum EStat
    {
        Str, Int, Agi, Cha, Cc, Ct, Spd, ResiP, ResiM, Hp, Mana, Pa
    }

    public enum EWeaponStat
    {
        Str, Int, Agi, Cha, Cc, Ct, Spd, ResiP, ResiM, Hp, Mana, Pa, DamageMin, DamageMax, Range
    }

    private static int _nbStatistic = 12;
    private static int _nbWeaponStatistic = 15;

    public static int NbStatistique
    {
        get { return _nbStatistic; }
    }

    public static int NbWeaponStatistic
    {
        get { return _nbWeaponStatistic; }
    }
}

