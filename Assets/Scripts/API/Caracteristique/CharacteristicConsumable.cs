using UnityEngine;
using System.Collections;

public class CharacteristicConsumable : Characteristic {

    public float ValeurActu { get; set; }

    public CharacteristicConsumable(float pValeur)
        : base(pValeur)
    {
        ValeurActu = pValeur;
    }

    public CharacteristicConsumable(CharacteristicConsumable pCaracConso)
        : base(pCaracConso)
        {
            ValeurActu = pCaracConso.ValeurActu;
        }

    public override void Reinitialisation()
    {
        base.Reinitialisation();

        if (ValeurActu > Valeur)
        {
            ValeurActu = Valeur;
        }
    }

    /// <summary>
    /// Change les valeurs usuelles mais également la valeur utilisée pour la réinitialisation
    /// </summary>
    /// <param name="value"></param>
    public override void ValueChange(float value)
    {
        base.ValueChange(value);

        ValeurActu += value - ValeurActu;
    }
}
