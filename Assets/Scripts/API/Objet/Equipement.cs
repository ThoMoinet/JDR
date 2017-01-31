using UnityEngine;
using System.Collections;

public class Equipement : Item {

    public Carac Str;
    public Carac Int;
    public Carac Agi;
    public Carac Cha;
    public Carac Cc;
    public Carac Ct;
    public Carac Pa;
    public Carac Spd;
    public Carac ResiP;
    public Carac ResiM;
    public Carac Hp;
    public Carac Mana;

    public Equipement(string pName, EGenreItem pGender, EQuality pQuality, int pWeight, Carac[] pCarac)
        : base(pName, pGender, pQuality, pWeight)
    {
        Str = new Carac(pCarac[(int)ECarac.Str]);
        Int = new Carac(pCarac[(int)ECarac.Int]);
        Agi = new Carac(pCarac[(int)ECarac.Agi]);
        Cha = new Carac(pCarac[(int)ECarac.Cha]);
        Cc = new Carac(pCarac[(int)ECarac.Cc]);
        Ct = new Carac(pCarac[(int)ECarac.Ct]);
        Pa = new Carac(pCarac[(int)ECarac.Pa]);
        Spd = new Carac(pCarac[(int)ECarac.Spd]);
        ResiP = new Carac(pCarac[(int)ECarac.ResiP]);
        ResiM = new Carac(pCarac[(int)ECarac.ResiM]);
        Hp = new Carac(pCarac[(int)ECarac.Hp]);
        Mana = new Carac(pCarac[(int)ECarac.Mana]);
    }

    public Equipement(Equipement pEquipement)
        : base(pEquipement)
    {
        Str = pEquipement.Str;
        Int = pEquipement.Int;
        Agi = pEquipement.Agi;
        Cha = pEquipement.Cha;
        Cc = pEquipement.Cc;
        Ct = pEquipement.Ct;
        Pa = pEquipement.Pa;
        Spd = pEquipement.Spd;
        ResiP = pEquipement.ResiP;
        ResiM = pEquipement.ResiM;
        Hp = pEquipement.Hp;
        Mana = pEquipement.Mana;
    }

    public Carac CaracWithEnum(Character.ECarac pECarac)
    {
        Carac temps = null;

        switch (pECarac)
        {
            case Character.ECarac.Agi:
                temps = Agi;
                break;
            case Character.ECarac.Cc:
                temps = Cc;
                break;
            case Character.ECarac.Cha:
                temps = Cha;
                break;
            case Character.ECarac.Ct:
                temps = Ct;
                break;
            case Character.ECarac.Hp:
                temps = Hp;
                break;
            case Character.ECarac.Int:
                temps = Int;
                break;
            case Character.ECarac.Mana:
                temps = Mana;
                break;
            case Character.ECarac.Pa:
                temps = Pa;
                break;
            case Character.ECarac.ResiM:
                temps = ResiM;
                break;
            case Character.ECarac.ResiP:
                temps = ResiP;
                break;
            case Character.ECarac.Spd:
                temps = Spd;
                break;
            case Character.ECarac.Str:
                temps = Str;
                break;
            default:
                break;
        }

        return temps;
    }
}
