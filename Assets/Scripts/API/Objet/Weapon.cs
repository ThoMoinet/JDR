using UnityEngine;
using System.Collections;

public class Weapon : Item
{
    public new EGenreWeapon Gender;

    private Characteristic[] _charac;

    public enum EGenreWeapon
    {
        Arme1M, Arme2M
    }

    public Weapon(string pName, EGenreWeapon pGender, EQuality pQuality, int pWeight, Characteristic[] pCarac)
        : base(pName, pQuality, pWeight)
    {
        _charac = pCarac;
        Gender = pGender;
    }

    public Weapon(Weapon pWeapon)
        : base(pWeapon)
    {
        _charac = pWeapon._charac;
    }

    public Characteristic Charac(Statistic.EStat pEStat)
    {
        return _charac[(int)pEStat];
    }
}
