using UnityEngine;
using System.Collections;

public class Equipment : Item {

    public new EGenreEquipment Gender;

    private Characteristic[] _charac;

    public enum EGenreEquipment
    {
        Tete, Torse, Main, Jambe, Pied, Bijoux
    }

    public Equipment(string pName, EGenreEquipment pGender, EQuality pQuality, int pWeight, Characteristic[] pCarac)
        : base(pName, pQuality, pWeight)
    {
        _charac = pCarac;
        Gender = pGender;
    }

    public Equipment(Equipment pEquipement)
        : base(pEquipement)
    {
        _charac = pEquipement._charac;
    }

    public Characteristic Charac(Statistic.EStat pEStat)
    {
        return _charac[(int)pEStat];
    }
}
