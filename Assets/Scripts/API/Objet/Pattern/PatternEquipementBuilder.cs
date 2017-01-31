using UnityEngine;
using System.Collections;

public class PatternEquipementBuilder : AleatoireBuilder
{
    public PatternEquipementBuilder() 
        : base()
    {
    }

    public override Aleatoire[] GetValues()
    {
        Aleatoire[] r = new Aleatoire[12];

        r[(int)Item.ECarac.Agi] = _agi;
        r[(int)Item.ECarac.Cc] = _cc;
        r[(int)Item.ECarac.Cha] = _cha;
        r[(int)Item.ECarac.Ct] = _ct;
        r[(int)Item.ECarac.Str] = _str;
        r[(int)Item.ECarac.Int] = _int;
        r[(int)Item.ECarac.Mana] = _mana;
        r[(int)Item.ECarac.Pa] = _pa;
        r[(int)Item.ECarac.Hp] = _hp;
        r[(int)Item.ECarac.ResiM] = _resiM;
        r[(int)Item.ECarac.ResiP] = _resiP;
        r[(int)Item.ECarac.Spd] = _spd;

        return r;
    }
}
