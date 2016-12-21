using UnityEngine;
using System.Collections;

public class CaracConso : Carac {

    public float ValeurActu { get; set; }

    public CaracConso(float pValeur)
        : base(pValeur)
    {
        ValeurActu = pValeur;
    }

    public CaracConso(CaracConso pCaracConso)
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

}
